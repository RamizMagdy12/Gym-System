using GymData.Models;
using GymServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMSWF
{
    public partial class InstructorForm : Form
    {
        private readonly CoachService _coachService;
        private List<GymData.Models.Instructor> _instructors = new();

        public InstructorForm()
        {
            InitializeComponent();
            var context = DbContext.CreateDbContext();
            _coachService = new CoachService(context);


        }

        private async void InstructorForm_Load(object sender, EventArgs e)
        {
            try
            {
                _instructors = await _coachService.GetAllCoaches();
                ShowInstructors(_instructors);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load instructors: " + ex.Message);
            }
        }

        private void ShowInstructors(IEnumerable<GymData.Models.Instructor> instructors)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var coach in instructors)
                flowLayoutPanel1.Controls.Add(CreateCard(coach));

            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel1.Refresh();
        }

        private InstructorCard CreateCard(GymData.Models.Instructor coach)
        {
            var card = new InstructorCard(coach)
            {
                Margin = new Padding(10)
            };
            card.InstructorDeleted += deletedCoach =>
            {
                _instructors.Remove(deletedCoach);
                flowLayoutPanel1.Controls.Remove(card);
            };
            return card;
        }

        public void SearchMethod()
        {
            string searchedName = searchTextBox.Text.Trim();
            IEnumerable<GymData.Models.Instructor> filtered = _instructors;
            if (!string.IsNullOrWhiteSpace(searchedName))
            {
                filtered = _instructors.Where(i =>
                    (i.ins_FName ?? "").StartsWith(searchedName, StringComparison.OrdinalIgnoreCase)
                    || (i.ins_LName ?? "").StartsWith(searchedName, StringComparison.OrdinalIgnoreCase)
                    || (i.FullName ?? "").Contains(searchedName, StringComparison.OrdinalIgnoreCase));
            }

            ShowInstructors(filtered);
        }

        private  void searchIconButton_Click(object sender, EventArgs e)
        {
            SearchMethod();
        }

        private void AddInstructorBTN_Click(object sender, EventArgs e)
        {
            var addForm = new AddInstructor();

            addForm.InstructorAdded += (coach) =>
            {
                _instructors.Add(coach);
                flowLayoutPanel1.Controls.Add(CreateCard(coach));
            };

            addForm.ShowDialog();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchMethod();
        }
    }
}
