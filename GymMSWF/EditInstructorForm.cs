using GymData.Models;
using GymServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMSWF
{
    public partial class EditInstructorForm : Form
    {
        private readonly CoachService _coachService;
        private Instructor _instructor;
        private string selectedImagePath;

        public event Action<Instructor> InstructorUpdated;

        public EditInstructorForm(Instructor instructor)
        {
            InitializeComponent();
            var context = DbContext.CreateDbContext();
            _coachService = new CoachService(context);

            _instructor = instructor;

            FNametextBox.Text = instructor.ins_FName;
            LNametextBox.Text = instructor.ins_LName;
            EmailtextBox.Text = instructor.ins_email;
            phonetextBox.Text = instructor.ins_phone;
            titletextBox.Text = instructor.ins_title;
            salarytextBox.Text = instructor.ins_salary.ToString();
            DateTimePicker.Value = instructor.ins_birth;

            if (instructor.ins_gender == "Female")
                femaleRadioButton.Checked = true;
            else
                maleRadioButton.Checked = true;

            selectedImagePath = instructor.ins_img;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.Image = ImageFiles.TryLoad(instructor.ins_img)
                ?? ImageFiles.Placeholder(instructor.ins_title, PictureBox.Size);
        }

        private async void editInsbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FNametextBox.Text) || string.IsNullOrWhiteSpace(LNametextBox.Text))
            {
                MessageBox.Show("Please enter the instructor name.");
                return;
            }

            if (!int.TryParse(salarytextBox.Text, out int salary) || salary < 0)
            {
                MessageBox.Show("Please enter a valid salary.");
                return;
            }

            try
            {
                _instructor.ins_FName = FNametextBox.Text.Trim();
                _instructor.ins_LName = LNametextBox.Text.Trim();
                _instructor.ins_email = EmailtextBox.Text.Trim();
                _instructor.ins_phone = phonetextBox.Text.Trim();
                _instructor.ins_title = titletextBox.Text.Trim();
                _instructor.ins_salary = salary;
                _instructor.ins_birth = DateTimePicker.Value;
                _instructor.ins_gender = femaleRadioButton.Checked ? "Female" : "Male";
                _instructor.ins_img = string.IsNullOrWhiteSpace(selectedImagePath)
                    ? selectedImagePath
                    : ImageFiles.Resolve(selectedImagePath) == selectedImagePath
                        ? selectedImagePath
                        : ImageFiles.Store(selectedImagePath);

                await _coachService.UpdateCoach(_instructor);
                InstructorUpdated?.Invoke(_instructor);

                MessageBox.Show("Instructor updated successfully ");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while updating: {ex.Message}");
            }
        }

        private void chooseImgeBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    PictureBox.Image = Image.FromFile(selectedImagePath);
                }
            }
        }
    }
}
