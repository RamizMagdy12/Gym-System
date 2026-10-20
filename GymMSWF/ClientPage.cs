using GymData;
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
	public partial class ClientPage : Form
	{
		private readonly ClientServices _clientService;
		private readonly PaymentServices _paymentService;
		private List<GymServices.Dtos.ClientDto> _clients = new();

		public ClientPage()
		{
			InitializeComponent();

			var context = DbContext.CreateDbContext();

			_clientService = new ClientServices(context);
			_paymentService = new PaymentServices(context);
			AddCheckInButton();
			ClientData.CellFormatting += ClientData_CellFormatting;
		}

		private void AddCheckInButton()
		{
			var checkIn = new Guna.UI2.WinForms.Guna2Button
			{
				Text = "Check in",
				Location = new Point(445, 32),
				Size = new Size(130, 44),
				FillColor = Color.FromArgb(61, 155, 150),
				ForeColor = Color.White,
				BorderRadius = 8,
				Font = new Font("Times New Roman", 10.2F, FontStyle.Bold)
			};
			checkIn.Click += CheckIn_Click;
			Controls.Add(checkIn);
			checkIn.BringToFront();
		}

		private void CheckIn_Click(object? sender, EventArgs e)
		{
			if (ClientData.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select a client to check in.");
				return;
			}

			int clientId = Convert.ToInt32(ClientData.SelectedRows[0].Cells["Id"].Value);
			using var context = DbContext.CreateDbContext();
			var attendance = new AttendanceService(context);
			var result = attendance.CheckIn(clientId);
			bool notSubscribed = !result.Success && result.Message.Contains("not subscribed", StringComparison.OrdinalIgnoreCase);
			MessageBox.Show(
				result.Message,
				result.Success ? "Checked in" : notSubscribed ? "Not subscribed" : "Attendance",
				MessageBoxButtons.OK,
				result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
		}


		private async Task LoadClients()
		{
			try
			{
				var clients = await _clientService.GetAllClients();
				_clients = clients
					.GroupBy(c => c.Id)
					.Select(g => g.First())
					.ToList();
				BindClients(_clients);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not load clients: " + ex.Message);
			}
		}

		private void BindClients(IEnumerable<GymServices.Dtos.ClientDto> clients)
		{
			ClientData.DataSource = clients.ToList();
			FormatDateColumn("BirthDate");
			FormatDateColumn("StartDate");
			FormatDateColumn("EndDate");
			RenameColumn("PackageTitle", "Package");
			RenameColumn("PaymentStatus", "Status");
			RenameColumn("PaymentsAmount", "Amount");
			RenameColumn("PaymentType", "Method");
		}

		private void RenameColumn(string columnName, string header)
		{
			if (ClientData.Columns.Contains(columnName))
				ClientData.Columns[columnName].HeaderText = header;
		}

		private void FormatDateColumn(string columnName)
		{
			if (ClientData.Columns.Contains(columnName))
				ClientData.Columns[columnName].DefaultCellStyle.Format = "yyyy-MM-dd";
		}

		private async void ClientPage_Load(object sender, EventArgs e)
		{
			await _paymentService.EnsureAllCyclePayments();
			await LoadClients();
		}

		private void ClientData_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex < 0 || ClientData.Columns[e.ColumnIndex].Name != "PaymentStatus")
				return;

			e.CellStyle.ForeColor = e.Value?.ToString() switch
			{
				"Active" => Color.FromArgb(120, 220, 140),
				"Unpaid" => Color.FromArgb(255, 196, 90),
				"Expired" or "Not started" => Color.FromArgb(255, 120, 120),
				_ => Color.White
			};
		}

		private void SearchTxt_TextChanged(object sender, EventArgs e)
		{
			string searchedText = SearchTxt.Text.Trim();
			IEnumerable<GymServices.Dtos.ClientDto> filtered = _clients;
			if (!string.IsNullOrWhiteSpace(searchedText))
			{
				filtered = _clients.Where(c =>
					(c.Name ?? "").StartsWith(searchedText, StringComparison.OrdinalIgnoreCase)
					|| (c.Phone ?? "").Contains(searchedText));
			}

			BindClients(filtered);
		}

		private async void Addbtn_Click(object sender, EventArgs e)
		{
			AddClient addClient = new AddClient();

			addClient.ShowDialog();

			await LoadClients();
		}

		private async void Deletebtn_Click(object sender, EventArgs e)
		{
			if (ClientData.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select a client to delete.");
				return;
			}

			int clientId = Convert.ToInt32(ClientData.SelectedRows[0].Cells["Id"].Value);

			var confirm = MessageBox.Show("Are you sure you want to delete this client?",
										  "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (confirm == DialogResult.Yes)
			{
				try
				{
					await _clientService.DeleteClient(clientId);
					await LoadClients();
					MessageBox.Show("Client deleted successfully.");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Could not delete the client: " + ex.Message);
				}
			}
		}

		private async void Updatebtn_Click(object sender, EventArgs e)
		{
			if (ClientData.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select a client to update.");
				return;
			}

			int clientId = Convert.ToInt32(ClientData.SelectedRows[0].Cells["Id"].Value);

			var client = await _clientService.GetClientById(clientId);
			if (client == null)
			{
				MessageBox.Show("Client not found.");
				return;
			}

			AddClient updateForm = new AddClient(client); 
			updateForm.ShowDialog();

			await LoadClients();
		}
	}
}
