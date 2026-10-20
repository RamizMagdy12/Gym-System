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
    public partial class Dashboard : Form
    {
        private readonly AttendanceService _attendanceService;
        private ClientServices _clientService = null!;
        private FontAwesome.Sharp.IconButton? _btnAttendance;
        private FontAwesome.Sharp.IconButton? _btnEquipment;
        private FontAwesome.Sharp.IconButton? _btnUsers;

        public Dashboard(string role)
        {
            InitializeComponent();
            _ = role;

            var context = DbContext.CreateDbContext();
            _attendanceService = new AttendanceService(context);
            _clientService = new ClientServices(context);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            mainPanel.AutoSize = false;
            mainPanel.Dock = DockStyle.Fill;
            panelDashboard.Dock = DockStyle.Fill;
            panelSidebar.Dock = DockStyle.Left;
            Controls.SetChildIndex(panelSidebar, Controls.Count - 1);
            AddEquipmentNavigation();
            AddAttendanceNavigation();
            AddUsersNavigation();
            ApplyMenuAccess();
        }

        private void Open(Form form, string screen)
        {
            if (!AppSession.CanView(screen))
            {
                MessageBox.Show("Your role cannot open this page.");
                return;
            }

            LoadForm(form);
            AppSession.HideMutations(form, screen);
        }

        private void ApplyMenuAccess()
        {
            btnDashboard.Visible = AppSession.CanView(AccessScreens.Dashboard);
            btnPackages.Visible = AppSession.CanView(AccessScreens.Packages);
            btnClients.Visible = AppSession.CanView(AccessScreens.Clients);
            btnInstructors.Visible = AppSession.CanView(AccessScreens.Instructors);
            btnMemberShips.Visible = AppSession.CanView(AccessScreens.Employees);
            btnPayments.Visible = AppSession.CanView(AccessScreens.Payments);
            if (_btnAttendance != null)
                _btnAttendance.Visible = AppSession.CanView(AccessScreens.Attendance);
            if (_btnEquipment != null)
                _btnEquipment.Visible = AppSession.CanView(AccessScreens.Equipment);
            if (_btnUsers != null)
                _btnUsers.Visible = AppSession.CanView(AccessScreens.Users);
        }

        private void AddUsersNavigation()
        {
            _btnUsers = new FontAwesome.Sharp.IconButton
            {
                Dock = DockStyle.Top,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Times New Roman", 9.75F, FontStyle.Bold),
                ForeColor = Color.White,
                IconChar = FontAwesome.Sharp.IconChar.UserShield,
                IconColor = Color.FromArgb(61, 155, 150),
                IconSize = 24,
                Name = "btnUsers",
                Size = new Size(181, 51),
                Text = "Users          ",
                TextAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            _btnUsers.FlatAppearance.BorderSize = 0;
            _btnUsers.Click += (_, _) => Open(new UsersForm(), AccessScreens.Users);
            panelSidebar.Controls.Add(_btnUsers);
            int index = panelSidebar.Controls.IndexOf(btnMemberShips);
            panelSidebar.Controls.SetChildIndex(_btnUsers, Math.Max(0, index));
        }

        private void AddAttendanceNavigation()
        {
            var btnAttendance = new FontAwesome.Sharp.IconButton
            {
                Dock = DockStyle.Top,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Times New Roman", 9.75F, FontStyle.Bold),
                ForeColor = Color.White,
                IconChar = FontAwesome.Sharp.IconChar.CalendarCheck,
                IconColor = Color.FromArgb(61, 155, 150),
                IconSize = 24,
                Name = "btnAttendance",
                Size = new Size(181, 51),
                Text = "Attendance   ",
                TextAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnAttendance.FlatAppearance.BorderSize = 0;
            btnAttendance.Click += (_, _) => Open(new AttendanceForm(), AccessScreens.Attendance);
            _btnAttendance = btnAttendance;
            panelSidebar.Controls.Add(btnAttendance);
            int clientIndex = panelSidebar.Controls.IndexOf(btnClients);
            panelSidebar.Controls.SetChildIndex(btnAttendance, Math.Max(0, clientIndex));
        }

        private void AddEquipmentNavigation()
        {
            var btnEquipment = new FontAwesome.Sharp.IconButton
            {
                Dock = DockStyle.Top,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Times New Roman", 9.75F, FontStyle.Bold),
                ForeColor = Color.White,
                IconChar = FontAwesome.Sharp.IconChar.Dumbbell,
                IconColor = Color.FromArgb(61, 155, 150),
                IconSize = 24,
                Name = "btnEquipment",
                Size = new Size(181, 52),
                Text = "Equipment      ",
                TextImageRelation = TextImageRelation.ImageBeforeText
            };
            btnEquipment.FlatAppearance.BorderSize = 0;
            btnEquipment.Click += (_, _) => Open(new EquipmentForm(), AccessScreens.Equipment);
            _btnEquipment = btnEquipment;
            panelSidebar.Controls.Add(btnEquipment);
            int menuIndex = panelSidebar.Controls.IndexOf(btnAbout);
            panelSidebar.Controls.SetChildIndex(btnEquipment, Math.Max(0, menuIndex));
        }

        public void LoadForm(Form form)
        {
            var existing = mainPanel.Controls.Cast<Control>().ToList();
            mainPanel.Controls.Clear();
            foreach (var control in existing)
                control.Dispose();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(form);
            form.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Open(new Dashboardd(), AccessScreens.Dashboard);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            LoadForm(new About());
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            Open(new Packages(), AccessScreens.Packages);
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            Open(new ClientPage(), AccessScreens.Clients);
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            Open(new InstructorForm(), AccessScreens.Instructors);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            Open(new PaymentForm(), AccessScreens.Payments);
        }

        private void btnMemberShips_Click(object sender, EventArgs e)
        {
            Open(new EmployeeForm(), AccessScreens.Employees);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadForm(new Home());
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                var overview = _clientService.GetOverview();
                label22.Text = overview.Packages.ToString();
                label19.Text = overview.ActiveMemberships.ToString();
                label16.Text = overview.MonthRevenue.ToString("C0");
                label20.Text = "Paid and current";
                label17.Text = "Collected this month";
                FitInCard(label22, panel14);
                FitInCard(label19, panel13);
                FitInCard(label16, panel12);

                var latest = _attendanceService.GetLastAttendances(1).FirstOrDefault();
                if (latest == null)
                {
                    ClientName.Text = "No check-in yet";
                    Package.Text = "—";
                    JoinDate.Text = "—";
                    EndDate.Text = "—";
                    TotalSessions.Text = "—";
                    AttendedSessions.Text = "—";
                    Remaining.Text = "—";
                    LastAttendance.Text = "—";
                    CurrentTime.Text = DateTime.Now.ToString("hh:mm tt");
                    PlaceCardValues();
                    return;
                }

                ShowMemberSummary(latest.MemberId);
            }
            catch (Exception ex)
            {
                ClientName.Text = "Unavailable";
                MessageBox.Show("Could not load the home cards: " + ex.Message);
            }
        }

        private void ShowMemberSummary(int clientId)
        {
            var summary = _attendanceService.GetClientAttendanceSummary(clientId);
            if (summary == null)
            {
                ClientName.Text = "Member not found";
                return;
            }

            ClientName.Text = summary.ClientName;
            Package.Text = summary.PackageName;
            JoinDate.Text = summary.JoinDate.ToString("dd MMM yyyy");
            EndDate.Text = summary.EndDate.ToString("dd MMM yyyy");
            TotalSessions.Text = summary.TotalSessions == 0 ? "Unlimited" : summary.TotalSessions.ToString();
            AttendedSessions.Text = summary.AttendedSessions.ToString();
            Remaining.Text = summary.TotalSessions == 0
                ? "Unlimited"
                : Math.Max(0, summary.RemainingSessions).ToString();
            LastAttendance.Text = summary.LastAttendanceDate?.ToString("dd MMM yyyy  hh:mm tt") ?? "No Previous";
            CurrentTime.Text = summary.CurrentAttendanceTime.ToString("hh:mm tt");
            PlaceCardValues();
        }

        private void PlaceCardValues()
        {
            PlaceName();
            Sit(label8, Package);
            Sit(label7, JoinDate);
            Sit(label6, EndDate);
            Sit(label2, LastAttendance);
            Sit(label1, CurrentTime);
            Sit(label5, TotalSessions);
            Sit(label4, AttendedSessions);
            Sit(label3, Remaining);
        }

        private void PlaceName()
        {
            int left = label9.Right + 10;
            int width = Math.Max(140, panel1.ClientSize.Width - left - 16);
            ClientName.AutoSize = false;
            ClientName.AutoEllipsis = true;
            ClientName.TextAlign = ContentAlignment.MiddleLeft;
            ClientName.SetBounds(left, label9.Top, width, label9.Height);
        }

        private static void FitInCard(Label value, Panel card)
        {
            value.AutoSize = true;
            value.MaximumSize = new Size(Math.Max(48, card.ClientSize.Width - 96), 32);
            int x = Math.Max(88, card.ClientSize.Width - value.PreferredWidth - 12);
            value.Location = new Point(x, 56);
            value.BringToFront();
        }

        private void Sit(Label caption, Label value)
        {
            var size = TextRenderer.MeasureText(value.Text, value.Font);
            int left = caption.Right + 8;
            int width = Math.Max(28, size.Width + 6);
            if (caption.Left < label5.Left)
                width = Math.Min(width, Math.Max(28, label5.Left - left - 8));
            else
                width = Math.Min(width, Math.Max(28, panel1.ClientSize.Width - left - 10));

            value.AutoSize = false;
            value.BackColor = Color.Transparent;
            value.SetBounds(left, caption.Top, width, Math.Max(caption.Height, size.Height));
            caption.BringToFront();
            value.BringToFront();
        }

        private void btnFAQ_Click(object sender, EventArgs e)
        {
            LoadForm(new FAQ());
        }
    }
}
