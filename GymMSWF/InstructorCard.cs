using GymData.Models;
using GymServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMSWF
{
    public partial class InstructorCard : UserControl
    {
        private readonly Instructor _coach;
        private readonly CoachService _coachService;
        public event Action<Instructor> InstructorDeleted;

        public InstructorCard(Instructor coach)
        {
            InitializeComponent();
            _coach = coach;
            var context = DbContext.CreateDbContext();
            _coachService = new CoachService(context);

            string fullName = $"{coach.ins_FName} {coach.ins_LName}".Trim();
            if (string.IsNullOrWhiteSpace(fullName))
                fullName = coach.ins_title;

            insName.Text = fullName;
            insLname.Text = string.IsNullOrWhiteSpace(coach.ins_LName) ? string.Empty : coach.ins_LName;
            insTitle.Text = fullName == coach.ins_title ? coach.ins_gender : coach.ins_title;
            insPhone.Text = coach.ins_phone;
            insImage.SizeMode = PictureBoxSizeMode.StretchImage;
            insImage.Image = ImageFiles.TryLoad(coach.ins_img) ?? ImageFiles.Placeholder(fullName, insImage.Size);
        }

        private async void deleteInsIconButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                $"Are you sure you want to delete {_coach.ins_FName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await _coachService.DeleteCoach(_coach.ins_id);
                    InstructorDeleted?.Invoke(_coach);
                    this.Dispose();
                    MessageBox.Show("Instructor deleted successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting instructor: {ex.Message}");
                }
            }
        }

        private void editIconButton_Click(object sender, EventArgs e)
        {
            var editForm = new EditInstructorForm(_coach);
            editForm.InstructorUpdated += (updatedCoach) =>
            {
                string updatedName = $"{updatedCoach.ins_FName} {updatedCoach.ins_LName}".Trim();
                if (string.IsNullOrWhiteSpace(updatedName))
                    updatedName = updatedCoach.ins_title;

                insName.Text = updatedName;
                insLname.Text = updatedCoach.ins_LName;
                insTitle.Text = updatedName == updatedCoach.ins_title ? updatedCoach.ins_gender : updatedCoach.ins_title;
                insPhone.Text = updatedCoach.ins_phone;
                insImage.Image = ImageFiles.TryLoad(updatedCoach.ins_img)
                    ?? ImageFiles.Placeholder(updatedName, insImage.Size);
            };

            editForm.ShowDialog();
        }
    }
}
