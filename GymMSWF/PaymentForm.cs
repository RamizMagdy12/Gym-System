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
	public partial class PaymentForm : Form
	{
		private readonly PaymentServices _paymentService;
		private List<GymData.Models.Payment> _payments = new();

		public PaymentForm()
		{
			InitializeComponent();

			var context = DbContext.CreateDbContext();
			_paymentService = new PaymentServices(context);
		}
		private async Task LoadPayments()
		{
			try
			{
				_payments = await _paymentService.GetAllPayments();
				BindPayments(_payments);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not load payments: " + ex.Message);
			}
		}

		private void BindPayments(IEnumerable<GymData.Models.Payment> payments)
		{
			paymentData.DataSource = payments.Select(p =>
			{
				var client = p.Client;
				int months = client == null || client.BillingMonths <= 0 ? 1 : client.BillingMonths;
				return new
				{
					ID = p.payment_id,
					Client = client?.client_name ?? "N/A",
					Package = client?.Package?.pack_title ?? "No package",
					Cycle = BillingCycle.Label(months),
					From = client?.startDate.ToString("yyyy-MM-dd") ?? "",
					To = client?.endDate.ToString("yyyy-MM-dd") ?? "",
					Amount = p.amount.ToString("0.00"),
					Method = p.payment_type,
					Invoice = p.payment_status,
					Status = client == null ? "" : Membership.Status(client)
				};
			}).ToList();

			paymentData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			if (paymentData.Columns.Contains("ID"))
				paymentData.Columns["ID"].Visible = false;
		}

		private async void Payment_Load(object sender, EventArgs e)
		{
			Addbtn.Text = "Collect";
			Updatebtn.Visible = false;
			Deletebtn.Visible = false;
			paymentData.CellFormatting += PaymentData_CellFormatting;
			await _paymentService.EnsureAllCyclePayments();
			await LoadPayments();
		}

		private void PaymentData_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex < 0 || paymentData.Columns[e.ColumnIndex].Name is not ("Invoice" or "Status"))
				return;

			e.CellStyle.ForeColor = e.Value?.ToString() switch
			{
				"Paid" or "Active" => Color.FromArgb(120, 220, 140),
				"Pending" or "Unpaid" => Color.FromArgb(255, 196, 90),
				"Expired" => Color.FromArgb(255, 120, 120),
				_ => Color.White
			};
		}

		private async void Addbtn_Click(object sender, EventArgs e)
		{
			if (paymentData.SelectedRows.Count == 0)
			{
				MessageBox.Show("Select the subscription invoice to collect.");
				return;
			}

			int paymentId = Convert.ToInt32(paymentData.SelectedRows[0].Cells["ID"].Value);
			var payment = await _paymentService.GetPaymentById(paymentId);
			if (payment == null)
			{
				MessageBox.Show("Payment not found.");
				return;
			}

			if (string.Equals(payment.payment_status, "Paid", StringComparison.OrdinalIgnoreCase))
			{
				var until = payment.Client?.endDate.ToString("dd MMM yyyy") ?? "the end of the cycle";
				MessageBox.Show($"This cycle is already paid. The client stays active until {until}.");
				return;
			}

			using var collect = new CollectPaymentForm(payment);
			if (collect.ShowDialog(this) != DialogResult.OK)
				return;

			try
			{
				await _paymentService.MarkPaid(paymentId, collect.Method);
				await LoadPayments();
				MessageBox.Show("Payment collected. The client status is now Active for this cycle.");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void SearchTxt_TextChanged(object sender, EventArgs e)
		{
			string searchedText = SearchTxt.Text.Trim();
			IEnumerable<GymData.Models.Payment> filtered = _payments;
			if (!string.IsNullOrWhiteSpace(searchedText))
			{
				filtered = _payments.Where(p =>
					(p.Client?.client_name ?? "").Contains(searchedText, StringComparison.OrdinalIgnoreCase)
					|| (p.Client?.Package?.pack_title ?? "").Contains(searchedText, StringComparison.OrdinalIgnoreCase)
					|| p.payment_status.Contains(searchedText, StringComparison.OrdinalIgnoreCase));
			}

			BindPayments(filtered);
		}

		private async void Deletebtn_Click(object sender, EventArgs e)
		{
			if (paymentData.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select a payment to delete.");
				return;
			}


			int paymentId = Convert.ToInt32(paymentData.SelectedRows[0].Cells["ID"].Value);

			var confirm = MessageBox.Show("Are you sure you want to delete this payment?",
										  "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (confirm == DialogResult.Yes)
			{
				await _paymentService.DeletePayment(paymentId);
				await LoadPayments();
				MessageBox.Show("Payment deleted successfully.");
			}
		}

		private async void Updatebtn_Click(object sender, EventArgs e)
		{
			if (paymentData.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select a payment to update.");
				return;
			}

			int paymentId = Convert.ToInt32(paymentData.SelectedRows[0].Cells["ID"].Value);

			var payment = await _paymentService.GetPaymentById(paymentId);
			if (payment == null)
			{
				MessageBox.Show("Payment not found.");
				return;
			}

			AddPayment updateForm = new AddPayment(payment); // نمرر الدفع للفورم
			updateForm.ShowDialog();

			await LoadPayments();
		}
	}
}
