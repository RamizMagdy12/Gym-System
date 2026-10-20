using GymData;
using GymData.Models;
using GymServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMSWF
{
    public partial class AddPackageForm : Form
    {
        private readonly PackageService _packageService;
        private readonly GymContextDB _context;
        private string _selectedImagePath = string.Empty;
        private readonly ComboBox _cycleCombo = new ComboBox();

        public Package NewPackage { get; private set; }

        public AddPackageForm()
        {
            InitializeComponent();
            _context = DbContext.CreateDbContext();
            _packageService = new PackageService(_context);
        }

        private void AddPackageForm_Load(object sender, EventArgs e)
        {
            var instructors = _context.instructors.ToList();

            comboInstructors.Sorted = false;
            comboInstructors.DataSource = instructors;
            comboInstructors.DisplayMember = nameof(Instructor.FullName);
            comboInstructors.ValueMember = nameof(Instructor.ins_id);
            comboInstructors.SelectedIndex = instructors.Count > 0 ? 0 : -1;

            _cycleCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            _cycleCombo.FlatStyle = FlatStyle.Flat;
            _cycleCombo.BackColor = Color.FromArgb(47, 61, 71);
            _cycleCombo.ForeColor = Color.White;
            _cycleCombo.Location = new Point(327, 358);
            _cycleCombo.Size = new Size(228, 28);
            _cycleCombo.DataSource = BillingCycle.Options.Select(months => new CycleChoice(months, BillingCycle.Label(months))).ToList();
            _cycleCombo.DisplayMember = nameof(CycleChoice.Label);
            _cycleCombo.ValueMember = nameof(CycleChoice.Months);
            Controls.Add(new Label
            {
                Text = "Cycle",
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Location = new Point(327, 336),
                AutoSize = true
            });
            Controls.Add(_cycleCombo);
            _cycleCombo.BringToFront();
        }

        private void AddImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    PictureAddPack.Image = Image.FromFile(openFile.FileName);
                    _selectedImagePath = openFile.FileName;
                }
            }
        }

        private async void SaveNewPackage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtcountSession.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                string.IsNullOrEmpty(_selectedImagePath) ||
                comboInstructors.SelectedItem == null)
            {
                MessageBox.Show("⚠️ Please fill all fields before saving.");
                return;
            }

           
            if (!int.TryParse(txtcountSession.Text, out int sessions) || sessions < 0)
            {
                MessageBox.Show("Sessions must be a whole number of zero or more.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Price must be a valid number of zero or more.");
                return;
            }

            int selectedInstructorId = 0;
            var selectedInstructor = comboInstructors.SelectedItem as Instructor;
            if (selectedInstructor != null)
                selectedInstructorId = selectedInstructor.ins_id;
            else if (comboInstructors.SelectedValue == null || !int.TryParse(comboInstructors.SelectedValue.ToString(), out selectedInstructorId))
            {
                MessageBox.Show("Please select an instructor.");
                return;
            }

            var newPackage = new Package
            {
                pack_title = txtTitle.Text.Trim(),
                pack_sessionsCount = sessions,
                pack_price = price,
                pack_desc = txtDescription.Text.Trim(),
                pack_img = ImageFiles.Store(_selectedImagePath),
                ins_id = selectedInstructorId,
                DurationMonths = _cycleCombo.SelectedValue is int months ? months : 1
            };

            try
            {
                await _packageService.AddPackageAsync(newPackage);
                MessageBox.Show("Package added successfully!");
                NewPackage = newPackage;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save the package: " + ex.Message);
            }
        }
    }
}
