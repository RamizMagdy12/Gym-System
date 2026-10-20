using GymServices;

namespace GymMSWF
{
    public partial class Home : Form
    {
        private readonly AttendanceService _attendanceService;
        private readonly ClientServices _clientService;

        public Home()
        {
            InitializeComponent();

            var context = DbContext.CreateDbContext();
            _attendanceService = new AttendanceService(context);
            _clientService = new ClientServices(context);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadOverview();
            var latest = _attendanceService.GetLastAttendances(1).FirstOrDefault();
            if (latest == null)
            {
                ShowEmptyCard();
                return;
            }

            ShowMember(latest.MemberId);
        }

        private void LoadOverview()
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the overview: " + ex.Message);
            }
        }

        private void ShowEmptyCard()
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
            PlaceValues();
        }

        private void ShowMember(int clientId)
        {
            var summary = _attendanceService.GetClientAttendanceSummary(clientId);
            if (summary == null)
            {
                ShowEmptyCard();
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
            LastAttendance.Text = summary.LastAttendanceDate?.ToString("dd MMM yyyy  hh:mm tt") ?? "No previous";
            CurrentTime.Text = summary.CurrentAttendanceTime.ToString("hh:mm tt");
            PlaceValues();
        }

        private void PlaceValues()
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
            value.MaximumSize = new Size(Math.Max(48, card.ClientSize.Width - 80), 28);
            int x = Math.Max(72, card.ClientSize.Width - value.PreferredWidth - 10);
            value.Location = new Point(x, 44);
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
    }
}
