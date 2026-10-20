using GymData.Models;
using GymServices;
using System.Drawing.Drawing2D;

namespace GymMSWF
{
    public partial class Dashboardd : Form
    {
        private readonly AttendanceService _attendanceService;
        private readonly FinanceService _financeService;
        private readonly Panel[] _bars = new Panel[7];
        private DonutChart _scheduledRing = null!;
        private DonutChart _paidRing = null!;
        private DonutChart _overdueRing = null!;

        public Dashboardd()
        {
            InitializeComponent();

            var context = DbContext.CreateDbContext();
            _attendanceService = new AttendanceService(context);
            _financeService = new FinanceService(context);
            PrepareCharts();
            panel8.Resize += (_, _) => ArrangeLayout();
        }

        private void Dashboard_load(object sender, EventArgs e)
        {
            ArrangeLayout();
            LoadWeeklyAttendance();
            LoadLastAttendances();
            LoadPackages();
            LoadFinanceSummary();
        }

        private void PrepareCharts()
        {
            panel8.Dock = DockStyle.Fill;
            panel11.Visible = false;

            foreach (var picture in new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 })
            {
                picture.Visible = false;
                picture.Parent?.Controls.Remove(picture);
            }

            iconButton2.Visible = false;

            for (int i = 0; i < _bars.Length; i++)
            {
                var bar = new Panel { BackColor = Color.Transparent, Width = 26 };
                bar.Paint += PaintAttendanceBar;
                panel1.Controls.Add(bar);
                _bars[i] = bar;
            }

            _scheduledRing = new DonutChart { Accent = Color.FromArgb(46, 204, 166) };
            _paidRing = new DonutChart { Accent = Color.FromArgb(190, 198, 214) };
            _overdueRing = new DonutChart { Accent = Color.FromArgb(214, 78, 92) };
            panel14.Controls.Add(_scheduledRing);
            panel14.Controls.Add(_paidRing);
            panel14.Controls.Add(_overdueRing);
            Scheduled.BringToFront();
            Paid.BringToFront();
            Overdue.BringToFront();
        }

        private void ArrangeLayout()
        {
            if (panel8.ClientSize.Width < 200)
                return;

            int pad = 18;
            int gap = 16;
            int width = panel8.ClientSize.Width;
            int height = panel8.ClientSize.Height;
            int columnWidth = Math.Max(320, (width - pad * 2 - gap) / 2);
            int topHeight = 210;
            int top = 48;

            label4.Location = new Point(pad, 12);
            label7.Location = new Point(pad, 32);
            iconButton4.Location = new Point(pad - 4, 6);

            panel14.SetBounds(pad, top, columnWidth, topHeight);
            panel1.SetBounds(pad + columnWidth + gap, top, columnWidth, topHeight);

            int bottomTop = top + topHeight + gap;
            int bottomHeight = Math.Max(240, height - bottomTop - pad);
            panel9.SetBounds(pad, bottomTop, columnWidth, bottomHeight);
            flowAttendances.SetBounds(pad + columnWidth + gap, bottomTop, columnWidth, bottomHeight);

            LayoutRings();
            LayoutAttendanceBars();
        }

        private void LayoutRings()
        {
            int ring = Math.Min(120, Math.Max(84, (panel14.Width - 48) / 3));
            int y = 42;
            int gap = Math.Max(12, (panel14.Width - ring * 3) / 4);
            PlaceRing(_scheduledRing, Scheduled, label23, gap, y, ring);
            PlaceRing(_paidRing, Paid, label3, gap * 2 + ring, y, ring);
            PlaceRing(_overdueRing, Overdue, label2, gap * 3 + ring * 2, y, ring);
        }

        private static void PlaceRing(DonutChart ring, Label amount, Label caption, int x, int y, int size)
        {
            ring.SetBounds(x, y, size, size);
            amount.Location = new Point(x + 8, y + size / 2 - 8);
            amount.BringToFront();
            caption.Location = new Point(x + Math.Max(0, (size - caption.Width) / 2), y + size + 4);
        }

        private void LayoutAttendanceBars()
        {
            Label[] dayLabels = { Day1, Day2, Day3, Day4, Day5, Day6, Day7 };
            Label[] countLabels = { Count1, Count2, Count3, Count4, Count5, Count6, Count7 };
            int left = 8;
            int baseline = Math.Max(80, panel1.Height - 28);
            int maxBar = Math.Max(36, baseline - 46);
            int available = Math.Max(7, panel1.Width - left - 8);
            int slot = available / 7;
            int barWidth = Math.Min(22, Math.Max(8, slot - 12));
            int max = _bars.Select(bar => bar.Tag is int n ? n : 0).DefaultIfEmpty(0).Max();
            if (max == 0)
                max = 1;

            for (int i = 0; i < 7; i++)
            {
                int value = _bars[i].Tag is int count ? count : 0;
                int height = value == 0 ? 4 : Math.Max(14, (int)(maxBar * (value / (float)max)));
                int x = left + i * slot + Math.Max(0, (slot - barWidth) / 2);
                _bars[i].SetBounds(x, baseline - height, barWidth, height);
                _bars[i].Invalidate();

                dayLabels[i].AutoSize = true;
                countLabels[i].AutoSize = true;
                dayLabels[i].Location = new Point(Math.Max(0, x + (barWidth - dayLabels[i].PreferredWidth) / 2), baseline + 2);
                int countTop = baseline - height - countLabels[i].PreferredHeight - 2;
                countLabels[i].Location = new Point(Math.Max(0, x + (barWidth - countLabels[i].PreferredWidth) / 2), Math.Max(30, countTop));
                dayLabels[i].BringToFront();
                countLabels[i].BringToFront();
                _bars[i].BringToFront();
            }
        }

        private static void PaintAttendanceBar(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel bar || bar.Width <= 0 || bar.Height <= 0)
                return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, bar.Width - 1, bar.Height - 1);
            using var brush = new LinearGradientBrush(rect, Color.FromArgb(128, 236, 186), Color.FromArgb(45, 168, 214), LinearGradientMode.Vertical);
            int radius = Math.Max(2, Math.Min(6, Math.Min(rect.Width, rect.Height) / 2));
            using var path = RoundedRect(rect, radius);
            e.Graphics.FillPath(brush, path);
        }

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void LoadWeeklyAttendance()
        {
            Label[] dayLabels = { Day1, Day2, Day3, Day4, Day5, Day6, Day7 };
            Label[] countLabels = { Count1, Count2, Count3, Count4, Count5, Count6, Count7 };

            for (int i = 0; i < 7; i++)
            {
                DateTime targetDate = DateTime.Today.AddDays(i - 6);
                dayLabels[i].Text = targetDate.ToString("ddd");
                label5.Text = $"Attendance · {DateTime.Today:MMM}";
                int count = _attendanceService.GetTodayAttendanceCount(targetDate);
                countLabels[i].Text = count.ToString();
                _bars[i].Tag = count;
            }

            LayoutAttendanceBars();
        }


        private List<Attendance> _lastAttendancesCache = new List<Attendance>();
        private Dictionary<int, int> _attendanceCounts = new Dictionary<int, int>();

        private bool IsSuccessfulCheckIn(Attendance attendance)
        {
            var client = attendance.Client;
            if (client == null)
                return false;

            _attendanceCounts.TryGetValue(client.client_id, out int attendedCount);
            int packageSessions = client.Package?.pack_sessionsCount ?? 0;
            bool unlimited = packageSessions == 0;
            bool withinSessions = unlimited || attendedCount <= packageSessions;
            return withinSessions && client.endDate.Date >= DateTime.Today;
        }

        private void LoadLastAttendances()
        {
            flowAttendances.Controls.Clear();
            _lastAttendancesCache = _attendanceService.GetLastAttendances(20);
            _attendanceCounts = _attendanceService.GetAttendanceCounts(
                _lastAttendancesCache.Where(a => a.Client != null).Select(a => a.Client.client_id));

            var headerPanel = new FlowLayoutPanel
            {
                Width = Math.Max(280, flowAttendances.ClientSize.Width - 24),
                Height = 72,
                BackColor = Color.FromArgb(241, 244, 246),
                Margin = new Padding(4),
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(8, 6, 8, 6)
            };

            var lblNotifi = new Label
            {
                Text = "Notifications",
                Font = new Font("Times New Roman", 12, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Teal,
                Margin = new Padding(4, 8, 12, 0)
            };

            var btnSortByStatus = CreateHeaderButton("Sort by Status");
            var btnSortByDate = CreateHeaderButton("Sort by Date");
            var btnClearFailed = CreateHeaderButton("Clear Failed");

            btnClearFailed.Click += (s, e) =>
            {
                // خزن كل البانلز اللي فيها رسالة فاشلة
                var toRemove = flowAttendances.Controls
                    .OfType<Panel>()
                    .Where(p => p.Controls.OfType<Label>()
                        .Any(lbl => lbl.Text.Contains("Not allowed")))
                    .ToList();

                foreach (var panel in toRemove)
                {
                    flowAttendances.Controls.Remove(panel);
                    panel.Dispose();
                }
            };

            // زرار حذف كل الرسائل الناجحة (Checked in successfully)
            var btnClearSuccess = CreateHeaderButton("Clear Success");

            btnClearSuccess.Click += (s, e) =>
            {
                var toRemove = flowAttendances.Controls
                    .OfType<Panel>()
                    .Where(p => p.Controls.OfType<Label>()
                        .Any(lbl => lbl.Text.Contains("Checked in")))
                    .ToList();

                foreach (var panel in toRemove)
                {
                    flowAttendances.Controls.Remove(panel);
                    panel.Dispose();
                }
            };

            headerPanel.Controls.Add(lblNotifi);
            headerPanel.Controls.Add(btnSortByStatus);
            headerPanel.Controls.Add(btnSortByDate);
            //headerPanel.Controls.Add(btnClearAll);
            headerPanel.Controls.Add(btnClearFailed);
            headerPanel.Controls.Add(btnClearSuccess);

            flowAttendances.Controls.Add(headerPanel);

            // =====================================

            DisplayAttendances(_lastAttendancesCache);

            btnSortByStatus.Click += (s, e) =>
            {
                var sorted = _lastAttendancesCache
                    .OrderByDescending(a => IsSuccessfulCheckIn(a))
                    .ToList();

                flowAttendances.Controls.Clear();
                flowAttendances.Controls.Add(headerPanel);
                DisplayAttendances(sorted);
            };

            btnSortByDate.Click += (s, e) =>
            {
                var sorted = _lastAttendancesCache
                    .OrderByDescending(a => a.AttendanceDate)
                    .ToList();

                flowAttendances.Controls.Clear();
                flowAttendances.Controls.Add(headerPanel);
                DisplayAttendances(sorted);
            };
        }


        private void DisplayAttendances(List<Attendance> attendances)
        {
            foreach (var att in attendances)
            {
                var client = att.Client;
                if (client == null) continue;

                bool success = IsSuccessfulCheckIn(att);

                int rowWidth = Math.Max(280, flowAttendances.ClientSize.Width - 28);
                var row = new Panel
                {
                    Width = rowWidth,
                    Height = 58,
                    BackColor = Color.FromArgb(248, 249, 250),
                    Margin = new Padding(4),
                    Padding = new Padding(8)
                };

                Label lblName = new Label();
                lblName.Text = client.client_name;
                lblName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblName.Location = new Point(10, 6);
                lblName.AutoSize = false;
                lblName.Size = new Size(rowWidth - 110, 22);
                lblName.ForeColor = Color.FromArgb(20, 40, 50);

                Label lblDate = new Label();
                lblDate.Text = success
                    ? att.AttendanceDate.ToString("dd MMM yyyy  hh:mm tt") + "   ·   Checked in"
                    : att.AttendanceDate.ToString("dd MMM yyyy  hh:mm tt") + "   ·   Not allowed";
                lblDate.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                lblDate.ForeColor = success ? Color.FromArgb(30, 140, 80) : Color.FromArgb(180, 50, 50);
                lblDate.Location = new Point(10, 30);
                lblDate.AutoSize = false;
                lblDate.Size = new Size(rowWidth - 110, 20);

                Button btnRemove = new Button();
                btnRemove.Text = "Dismiss";
                btnRemove.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                btnRemove.ForeColor = Color.Black;
                btnRemove.BackColor = Color.FromArgb(232, 236, 239);
                btnRemove.FlatStyle = FlatStyle.Flat;
                btnRemove.FlatAppearance.BorderSize = 1;
                btnRemove.Size = new Size(72, 26);
                btnRemove.Location = new Point(rowWidth - 84, 16);
                btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                btnRemove.Click += (s, e) =>
                {
                    flowAttendances.Controls.Remove(row);
                    row.Dispose();
                };

                Panel separator = new Panel();
                separator.Height = 2;
                separator.Dock = DockStyle.Bottom;
                separator.BackColor = Color.FromArgb(214, 220, 224);

                row.Controls.Add(lblName);
                row.Controls.Add(lblDate);
                row.Controls.Add(btnRemove);
                row.Controls.Add(separator);
                flowAttendances.Controls.Add(row);
            }
        }



        private static Button CreateHeaderButton(string text)
        {
            var button = new Button
            {
                Text = text,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MinimumSize = new Size(110, 30),
                Margin = new Padding(4, 2, 4, 2),
                Font = new Font("Times New Roman", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(241, 244, 246),
                FlatStyle = FlatStyle.Flat,
                Padding = new Padding(8, 2, 8, 2)
            };
            button.FlatAppearance.BorderSize = 1;
            return button;
        }

        private void LoadPackages()
        {
            foreach (var label in new[] { PackageTitle, PackageTitle1, PackageStart, PackageStart1, PackageIns, PackageIns1 })
                label.Visible = false;
            iconButton3.Visible = false;
            panel17.Visible = false;

            foreach (var row in panel9.Controls.OfType<Panel>().Where(p => Equals(p.Tag, "schedule-row")).ToList())
            {
                panel9.Controls.Remove(row);
                row.Dispose();
            }

            var packages = _attendanceService.GetAllPackagesWithInstructor();
            int y = 78;
            if (packages.Count == 0)
            {
                var empty = new Label
                {
                    Text = "No upcoming packages",
                    ForeColor = Color.Teal,
                    Font = new Font("Times New Roman", 11, FontStyle.Bold),
                    Location = new Point(20, y),
                    AutoSize = true,
                    Tag = "schedule-row"
                };
                panel9.Controls.Add(empty);
                return;
            }

            foreach (var package in packages.Take(5))
            {
                var row = new Panel
                {
                    Tag = "schedule-row",
                    Location = new Point(16, y),
                    Size = new Size(panel9.Width - 32, 58),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    BackColor = Color.FromArgb(241, 244, 246)
                };

                row.Controls.Add(new Label
                {
                    Text = package.StartDate is { Year: >= 2000 } start ? start.ToString("dd MMM yyyy") : "No start date",
                    Font = new Font("Times New Roman", 11, FontStyle.Bold),
                    ForeColor = Color.Teal,
                    Location = new Point(4, 4),
                    AutoSize = true
                });
                row.Controls.Add(new Label
                {
                    Text = package.PackageName,
                    Font = new Font("Times New Roman", 12, FontStyle.Bold),
                    ForeColor = Color.Teal,
                    Location = new Point(4, 26),
                    AutoSize = true
                });
                row.Controls.Add(new Label
                {
                    Text = package.InstructorName,
                    Font = new Font("Times New Roman", 10, FontStyle.Bold),
                    ForeColor = Color.DimGray,
                    Location = new Point(Math.Max(140, row.Width - 160), 28),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    AutoSize = true
                });

                var line = new Panel
                {
                    Height = 1,
                    Dock = DockStyle.Bottom,
                    BackColor = Color.FromArgb(214, 220, 224)
                };
                row.Controls.Add(line);
                panel9.Controls.Add(row);
                y += 62;
            }
        }

        private void LoadFinanceSummary()
        {
            var finance = _financeService.GetMonthlyFinanceSummary();
            var payments = _financeService.GetPaymentMonthSummary();

            decimal scheduled = finance.Scheduled > 0 ? finance.Scheduled : payments.Scheduled;
            decimal paid = finance.Scheduled > 0 ? finance.Paid : payments.Paid;
            decimal overdue = finance.Scheduled > 0 ? finance.Overdue : payments.Overdue;
            if (finance.Scheduled == 0)
                label24.Text = $"Payments · {payments.Period}";

            Scheduled.Text = scheduled.ToString("C0");
            Paid.Text = paid.ToString("C0");
            Overdue.Text = overdue.ToString("C0");

            float total = scheduled <= 0 ? 0 : 1;
            _scheduledRing.Fraction = total;
            _paidRing.Fraction = scheduled <= 0 ? 0 : (float)(paid / scheduled);
            _overdueRing.Fraction = scheduled <= 0 ? 0 : (float)(overdue / scheduled);
            LayoutRings();
        }

    }
}
