using GymData.Models;
using GymServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace GymMSWF
{

    public partial class AddInstructor : Form
    {
        private readonly CoachService _coachService;
        public event Action<Instructor> InstructorAdded;
        private string selectedImagePath = null;


        public AddInstructor()
        {
            InitializeComponent();
            var context = DbContext.CreateDbContext();
            _coachService = new CoachService(context);
        }

        private async void AddInsbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FNametextBox.Text))
            {
                MessageBox.Show("Please Enter First Name");
                return;
            }
            if (string.IsNullOrWhiteSpace(LNametextBox.Text))
            {
                MessageBox.Show("Please Enter Last Name");
                return;
            }
            if (string.IsNullOrWhiteSpace(titletextBox.Text))
            {
                MessageBox.Show("Please Enter Instructor title");
                return;
            }
            if (string.IsNullOrWhiteSpace(phonetextBox.Text))
            {
                MessageBox.Show("Please Enter Instructor phone");
                return;
            }
            if (!string.IsNullOrWhiteSpace(EmailtextBox.Text) &&
               !Regex.IsMatch(EmailtextBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(phonetextBox.Text, @"^\d{8,15}$"))
            {
                MessageBox.Show("Phone number must contain only digits (8–15 digits).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!maleRadioButton.Checked && !femaleRadioButton.Checked)
            {
                MessageBox.Show("please Choose Gender");
                return;
            }

            if (!int.TryParse(salarytextBox.Text, out int salary) || salary < 0)
            {
                MessageBox.Show("Please enter a valid salary.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string gender = femaleRadioButton.Checked ? "Female" : "Male";
            var instructor = new Instructor
            {
                ins_FName = FNametextBox.Text.Trim(),
                ins_LName = LNametextBox.Text.Trim(),
                ins_email = EmailtextBox.Text.Trim(),
                ins_phone = phonetextBox.Text.Trim(),
                ins_title = titletextBox.Text.Trim(),
                ins_salary = salary,
                ins_img = selectedImagePath == null ? null : ImageFiles.Store(selectedImagePath),
                ins_gender = gender,
                ins_birth = DateTimePicker.Value,
            };

            try
            {
                await _coachService.AddCoach(instructor);
                InstructorAdded?.Invoke(instructor);
                MessageBox.Show("Instructor Added Successfully ");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add the instructor: " + ex.Message);
            }




        }

        private void chooseImgeBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Choose Instructor Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    PictureBox.Image = Image.FromFile(selectedImagePath);
                }
            }
        }
    }
}
