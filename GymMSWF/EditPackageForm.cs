using GymData;
using GymData.Models;
using GymServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Package = GymData.Models.Package;

namespace GymMSWF
{
    public partial class EditPackageForm : Form
    {
        private readonly PackageService _packageService;
        private readonly GymContextDB _context;
        private Package _package;
        private readonly ComboBox _cycleCombo = new ComboBox();


        public EditPackageForm(int packageId)
        {
            InitializeComponent();
            _context = DbContext.CreateDbContext();
            _packageService = new PackageService(_context);
            LoadPackageData(packageId);
        }

        private void LoadPackageData(int id)
        {
            _package = _packageService.GetPackageById(id);
            if (_package == null)
            {
                MessageBox.Show("Package not found!");
                this.Close();
                return;
            }

            txtTitle.Text = _package.pack_title;
            txtPrice.Text = _package.pack_price.ToString();
            txtSessions.Text = _package.pack_sessionsCount.ToString();
            txtDescription.Text = _package.pack_desc;

            picPackage.Image = ImageFiles.TryLoad(_package.pack_img)
                ?? ImageFiles.Placeholder(_package.pack_title, picPackage.Size);
        }
        public Package UpdatedPackage { get; private set; }


        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (_package == null)
                return;

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a package title.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Price must be a valid number of zero or more.");
                return;
            }

            if (!int.TryParse(txtSessions.Text, out int sessions) || sessions < 0)
            {
                MessageBox.Show("Sessions must be a whole number of zero or more.");
                return;
            }

            try
            {
                _package.pack_title = txtTitle.Text.Trim();
                _package.pack_price = price;
                _package.pack_sessionsCount = sessions;
                _package.pack_desc = txtDescription.Text.Trim();

                if (comboEditInstructor.SelectedValue != null && int.TryParse(comboEditInstructor.SelectedValue.ToString(), out int coachId))
                    _package.ins_id = coachId;

                _package.DurationMonths = _cycleCombo.SelectedValue is int months ? months : 1;

                await _packageService.UpdatePackageAsync(_package);

                UpdatedPackage = _package;

                MessageBox.Show("✅ Package updated successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                _package.pack_img = ImageFiles.Store(openFile.FileName);
                picPackage.Image = ImageFiles.TryLoad(_package.pack_img);
            }
        }

        private void EditPackageForm_Load(object sender, EventArgs e)
        {
            if (_package == null)
                return;

            var instructors = _context.instructors.ToList();

            comboEditInstructor.DataSource = instructors;
            comboEditInstructor.DisplayMember = nameof(Instructor.FullName);
            comboEditInstructor.ValueMember = nameof(Instructor.ins_id);

            _cycleCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            _cycleCombo.FlatStyle = FlatStyle.Flat;
            _cycleCombo.BackColor = Color.FromArgb(47, 61, 71);
            _cycleCombo.ForeColor = Color.White;
            _cycleCombo.Location = new Point(259, 366);
            _cycleCombo.Size = new Size(241, 28);
            _cycleCombo.DataSource = BillingCycle.Options.Select(months => new CycleChoice(months, BillingCycle.Label(months))).ToList();
            _cycleCombo.DisplayMember = nameof(CycleChoice.Label);
            _cycleCombo.ValueMember = nameof(CycleChoice.Months);
            if (!Controls.Contains(_cycleCombo))
            {
                Controls.Add(new Label
                {
                    Text = "Cycle",
                    ForeColor = Color.White,
                    Location = new Point(259, 344),
                    AutoSize = true
                });
                Controls.Add(_cycleCombo);
            }
            _cycleCombo.SelectedValue = _package.DurationMonths <= 0 ? 1 : _package.DurationMonths;
            _cycleCombo.BringToFront();

            txtTitle.Text = _package.pack_title;
            txtDescription.Text = _package.pack_desc;
            txtPrice.Text = _package.pack_price.ToString();
            txtSessions.Text = _package.pack_sessionsCount.ToString();

            picPackage.Image = ImageFiles.TryLoad(_package.pack_img)
                ?? ImageFiles.Placeholder(_package.pack_title, picPackage.Size);

            
            comboEditInstructor.SelectedValue = _package.ins_id;
        }
    }
}

