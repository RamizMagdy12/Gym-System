using GymServices;
using GymServices.Dtos;

namespace GymMSWF
{
	public class AttendanceForm : Form
	{
		private readonly AttendanceService _attendanceService;
		private List<AttendanceBoardItem> _rows = new();
		private readonly TextBox _search = new();
		private readonly DataGridView _clients = new();
		private readonly DataGridView _today = new();
		private readonly Label _name = new();
		private readonly Label _package = new();
		private readonly Label _status = new();
		private readonly Label _attended = new();
		private readonly Label _remaining = new();
		private readonly Label _note = new();
		private readonly Button _checkIn = new();
		private Panel _detail = null!;
		private Panel _stack = null!;

		public AttendanceForm()
		{
			var context = DbContext.CreateDbContext();
			_attendanceService = new AttendanceService(context);

			Text = "Attendance";
			BackColor = Color.FromArgb(36, 48, 56);
			ForeColor = Color.White;
			Font = new Font("Segoe UI", 10F);
			AutoScaleMode = AutoScaleMode.None;

			BuildLayout();
			Load += (_, _) => Reload();
		}

		private void BuildLayout()
		{
			var header = new TableLayoutPanel
			{
				Dock = DockStyle.Top,
				Height = 64,
				BackColor = Color.FromArgb(47, 61, 71),
				ColumnCount = 3,
				RowCount = 1,
				Padding = new Padding(12, 8, 12, 8)
			};
			header.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
			header.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
			header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
			header.Controls.Add(new Label
			{
				Text = "Attendance",
				Font = new Font("Segoe UI", 16F, FontStyle.Bold),
				ForeColor = Color.White,
				AutoSize = true,
				Margin = new Padding(4, 10, 12, 0),
				Anchor = AnchorStyles.Left
			}, 0, 0);
			header.Controls.Add(new Label
			{
				Text = DateTime.Today.ToString("MMMM yyyy"),
				Font = new Font("Segoe UI", 10F),
				ForeColor = Color.FromArgb(160, 170, 190),
				AutoSize = true,
				Margin = new Padding(0, 16, 16, 0),
				Anchor = AnchorStyles.Left
			}, 1, 0);
			_search.PlaceholderText = "Search client...";
			_search.Dock = DockStyle.Fill;
			_search.Margin = new Padding(8, 8, 4, 8);
			_search.Font = new Font("Segoe UI", 10F);
			_search.TextChanged += (_, _) => BindClients(Filter());
			header.Controls.Add(_search, 2, 0);

			_detail = new Panel
			{
				Dock = DockStyle.Right,
				Width = 300,
				BackColor = Color.FromArgb(47, 61, 71)
			};
			_stack = new Panel
			{
				Dock = DockStyle.Fill,
				AutoScroll = true,
				Padding = new Padding(16, 12, 12, 8),
				BackColor = Color.FromArgb(47, 61, 71)
			};
			_detail.Resize += (_, _) => FitDetail();
			_name.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
			_name.ForeColor = Color.White;
			_name.AutoSize = true;
			_name.MaximumSize = new Size(270, 0);
			_name.Text = "Select a client";
			_package.ForeColor = Color.FromArgb(180, 190, 205);
			_package.AutoSize = true;
			_package.MaximumSize = new Size(270, 0);
			_status.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			_status.AutoSize = true;
			_attended.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
			_attended.ForeColor = Color.White;
			_attended.AutoSize = true;
			_remaining.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
			_remaining.ForeColor = Color.FromArgb(61, 155, 150);
			_remaining.AutoSize = true;
			_note.ForeColor = Color.White;
			_note.AutoSize = true;
			_note.MaximumSize = new Size(270, 0);

			_checkIn.Text = "Check in";
			_checkIn.Dock = DockStyle.Bottom;
			_checkIn.Height = 48;
			_checkIn.BackColor = Color.FromArgb(74, 169, 81);
			_checkIn.ForeColor = Color.White;
			_checkIn.FlatStyle = FlatStyle.Flat;
			_checkIn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
			_checkIn.Enabled = false;
			_checkIn.FlatAppearance.BorderSize = 0;
			_checkIn.Click += (_, _) => CheckInSelected();

			_stack.Controls.Add(_name);
			_stack.Controls.Add(_package);
			_stack.Controls.Add(_status);
			_stack.Controls.Add(Caption("This month"));
			_stack.Controls.Add(_attended);
			_stack.Controls.Add(Caption("Remaining"));
			_stack.Controls.Add(_remaining);
			_stack.Controls.Add(_note);
			_detail.Controls.Add(_stack);
			_detail.Controls.Add(_checkIn);

			var todayPanel = new Panel
			{
				Dock = DockStyle.Bottom,
				Height = 190,
				BackColor = Color.FromArgb(36, 48, 56),
				Padding = new Padding(8, 4, 8, 8)
			};
			todayPanel.Controls.Add(new Label
			{
				Text = "Today",
				Dock = DockStyle.Top,
				Height = 28,
				ForeColor = Color.White,
				Font = new Font("Segoe UI", 11F, FontStyle.Bold)
			});
			StyleGrid(_today);
			_today.Dock = DockStyle.Fill;
			todayPanel.Controls.Add(_today);

			StyleGrid(_clients);
			_clients.Dock = DockStyle.Fill;
			_clients.SelectionChanged += (_, _) => ShowSelected();
			_clients.CellDoubleClick += (_, _) => CheckInSelected();
			_clients.CellFormatting += Clients_CellFormatting;

			Controls.Add(_clients);
			Controls.Add(todayPanel);
			Controls.Add(_detail);
			Controls.Add(header);
		}

		private void FitDetail()
		{
			if (_stack == null)
				return;

			int width = Math.Max(140, _stack.ClientSize.Width - 8);
			int y = 4;
			foreach (Control control in _stack.Controls)
			{
				if (control is not Label label)
					continue;

				label.AutoSize = false;
				var size = TextRenderer.MeasureText(
					string.IsNullOrEmpty(label.Text) ? " " : label.Text,
					label.Font,
					new Size(width, 600),
					TextFormatFlags.WordBreak);
				int height = Math.Max(label.Font.Height + 2, size.Height);
				label.SetBounds(0, y, width, height);
				y += height + 8;
			}
		}

		private static Label Caption(string text)
		{
			return new Label
			{
				Text = text,
				ForeColor = Color.FromArgb(160, 170, 190),
				Font = new Font("Segoe UI", 9F),
				AutoSize = true,
				Margin = new Padding(0, 10, 0, 0)
			};
		}

		private static void StyleGrid(DataGridView grid)
		{
			grid.ReadOnly = true;
			grid.AllowUserToAddRows = false;
			grid.AllowUserToDeleteRows = false;
			grid.AllowUserToResizeRows = false;
			grid.RowHeadersVisible = false;
			grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			grid.MultiSelect = false;
			grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			grid.BackgroundColor = Color.FromArgb(36, 48, 56);
			grid.BorderStyle = BorderStyle.None;
			grid.EnableHeadersVisualStyles = false;
			grid.ColumnHeadersHeight = 34;
			grid.RowTemplate.Height = 32;
			grid.GridColor = Color.FromArgb(47, 61, 71);
			grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(61, 155, 150);
			grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(61, 155, 150);
			grid.DefaultCellStyle.BackColor = Color.FromArgb(36, 48, 56);
			grid.DefaultCellStyle.ForeColor = Color.White;
			grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(74, 169, 81);
			grid.DefaultCellStyle.SelectionForeColor = Color.White;
			grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40, 52, 60);
			grid.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
		}

		private void Reload(int? keepClientId = null)
		{
			try
			{
				_rows = _attendanceService.GetBoard();
				BindClients(Filter(), keepClientId);
				BindToday();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not load attendance: " + ex.Message);
			}
		}

		private IEnumerable<AttendanceBoardItem> Filter()
		{
			string text = _search.Text.Trim();
			if (string.IsNullOrWhiteSpace(text))
				return _rows;

			return _rows.Where(r =>
				r.Name.Contains(text, StringComparison.OrdinalIgnoreCase)
				|| r.Phone.Contains(text, StringComparison.OrdinalIgnoreCase)
				|| r.Package.Contains(text, StringComparison.OrdinalIgnoreCase));
		}

		private void BindClients(IEnumerable<AttendanceBoardItem> rows, int? keepClientId = null)
		{
			var list = rows.ToList();
			_clients.DataSource = list.Select(r => new
			{
				r.ClientId,
				r.Name,
				r.Phone,
				r.Package,
				r.Status,
				Sessions = r.AllowedSessions <= 0 ? $"{r.AttendedThisMonth} / unlimited" : $"{r.AttendedThisMonth} / {r.AllowedSessions}",
				r.Remaining,
				Today = r.CheckedInToday ? "Yes" : "",
				r.LastVisit
			}).ToList();

			if (_clients.Columns.Contains("ClientId"))
				_clients.Columns["ClientId"].Visible = false;

			if (keepClientId != null)
			{
				foreach (DataGridViewRow row in _clients.Rows)
				{
					if (Convert.ToInt32(row.Cells["ClientId"].Value) == keepClientId.Value)
					{
						row.Selected = true;
						_clients.FirstDisplayedScrollingRowIndex = row.Index;
						break;
					}
				}
			}

			ShowSelected();
		}

		private void BindToday()
		{
			_today.DataSource = _attendanceService.GetTodayAttendances().Select(a => new
			{
				Time = a.AttendanceDate.ToString("hh:mm tt"),
				Client = a.Client?.client_name ?? "N/A",
				Package = a.Client?.Package?.pack_title ?? ""
			}).ToList();
		}

		private AttendanceBoardItem? Selected()
		{
			if (_clients.SelectedRows.Count == 0)
				return null;
			int id = Convert.ToInt32(_clients.SelectedRows[0].Cells["ClientId"].Value);
			return _rows.FirstOrDefault(r => r.ClientId == id);
		}

		private void ShowSelected()
		{
			var row = Selected();
			_checkIn.Enabled = row != null;
			if (row == null)
			{
				_name.Text = "Select a client";
				_package.Text = "";
				_status.Text = "";
				_attended.Text = "";
				_remaining.Text = "";
				_note.Text = "";
				return;
			}

			_name.Text = row.Name;
			_package.Text = row.Package;
			_status.Text = row.Status;
			_status.ForeColor = StatusColor(row.Status);
			_attended.Text = row.AllowedSessions <= 0
				? $"{row.AttendedThisMonth}  /  unlimited"
				: $"{row.AttendedThisMonth}  /  {row.AllowedSessions}";
			_remaining.Text = row.Remaining;
			_note.Text = row.Note;
			_note.ForeColor = row.CanCheckIn ? Color.FromArgb(120, 220, 140) : Color.FromArgb(255, 196, 90);
			FitDetail();
		}

		private void Clients_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex < 0 || e.CellStyle == null || _clients.Columns[e.ColumnIndex].Name != "Status")
				return;

			e.CellStyle.ForeColor = StatusColor(e.Value?.ToString());
		}

		private static Color StatusColor(string? status)
		{
			return status switch
			{
				"Active" => Color.FromArgb(120, 220, 140),
				"Unpaid" => Color.FromArgb(255, 196, 90),
				_ => Color.FromArgb(255, 120, 120)
			};
		}

		private void CheckInSelected()
		{
			var row = Selected();
			if (row == null)
			{
				MessageBox.Show("Select a client to check in.");
				return;
			}

			var result = _attendanceService.CheckIn(row.ClientId);
			bool notSubscribed = !result.Success && result.Message.Contains("not subscribed", StringComparison.OrdinalIgnoreCase);
			MessageBox.Show(
				result.Message,
				result.Success ? "Checked in" : notSubscribed ? "Not subscribed" : "Attendance",
				MessageBoxButtons.OK,
				result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
			Reload(row.ClientId);
		}
	}
}
