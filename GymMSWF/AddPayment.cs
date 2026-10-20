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
	public partial class AddPayment : Form
	{
		private readonly PaymentServices _paymentService;
		private readonly ClientServices _clientService;
		private readonly Payment? _existingPayment;
		private bool _loadingClients;

		public AddPayment()
		{
			InitializeComponent();
			var context = DbContext.CreateDbContext();
			_paymentService = new PaymentServices(context);
			_clientService = new ClientServices(context);
			nameClientCombo.SelectedIndexChanged += nameClientCombo_SelectedIndexChanged;
			this.Load += AddPayment_Load;
		}
		private async void AddPayment_Load(object? sender, EventArgs e)
		{
			await LoadClients();
		}


		public AddPayment(Payment payment)
		{
			InitializeComponent();
			var context = DbContext.CreateDbContext();
			_paymentService = new PaymentServices(context);
			_clientService = new ClientServices(context);
			_existingPayment = payment;
			nameClientCombo.SelectedIndexChanged += nameClientCombo_SelectedIndexChanged;
			LoadClientDataAsync(payment);
		}

		private async Task LoadClients(int? includeClientId = null)
		{
			_loadingClients = true;
			try
			{
				var clients = await _clientService.GetAllClients();
				var availableClients = clients
					.Where(c => string.IsNullOrEmpty(c.PaymentStatus) || c.Id == includeClientId)
					.GroupBy(c => c.Id)
					.Select(g => g.First())
					.ToList();

				nameClientCombo.DataSource = availableClients;
				nameClientCombo.DisplayMember = "Name";
				nameClientCombo.ValueMember = "Id";
				if (includeClientId != null)
					nameClientCombo.SelectedValue = includeClientId.Value;
				else if (availableClients.Count == 0)
					nameClientCombo.SelectedIndex = -1;
			}
			finally
			{
				_loadingClients = false;
			}
		}

		private async void LoadClientDataAsync(Payment payment)
		{
			await LoadClients(payment.client_id);

			Addbtn.Text = "Update";
			Addbtn.FillColor = Color.FromArgb(61, 155, 150);
			PTypeCombo.Text = payment.payment_type;
			PStatusCombo.Text = payment.payment_status;
			CreatedAtTime.Value = payment.created_at;
			nameClientCombo.SelectedValue = payment.client_id;
			AmountTxt.Text = payment.amount.ToString("0.00");
		}

		private bool TryReadPayment(out string paymentType, out decimal amount, out string status, out int clientId)
		{
			paymentType = PTypeCombo.Text.Trim();
			amount = 0;
			status = PStatusCombo.SelectedItem?.ToString() ?? PStatusCombo.Text.Trim();
			clientId = 0;

			if (string.IsNullOrWhiteSpace(paymentType))
			{
				MessageBox.Show("Please select a payment type.");
				return false;
			}

			if (string.IsNullOrWhiteSpace(status))
			{
				MessageBox.Show("Please select a payment status.");
				return false;
			}

			if (!decimal.TryParse(AmountTxt.Text, out amount) || amount <= 0)
			{
				MessageBox.Show("Please enter a valid amount greater than zero.");
				return false;
			}

			if (nameClientCombo.SelectedValue == null || !int.TryParse(nameClientCombo.SelectedValue.ToString(), out clientId))
			{
				MessageBox.Show("Please select a client.");
				return false;
			}

			return true;
		}

		private async void Addbtn_Click(object sender, EventArgs e)
		{
			if (!TryReadPayment(out string paymentType, out decimal amount, out string status, out int clientId))
				return;

			try
			{
				if (_existingPayment == null)
				{
					var newPayment = new GymData.Models.Payment
					{
						payment_type = paymentType,
						amount = amount,
						payment_status = status,
						created_at = CreatedAtTime.Value.Date,
						client_id = clientId
					};

					await _paymentService.AddPayment(newPayment);
					MessageBox.Show("Payment added successfully!");
				}
				else
				{
					_existingPayment.payment_type = paymentType;
					_existingPayment.amount = amount;
					_existingPayment.payment_status = status;
					_existingPayment.created_at = CreatedAtTime.Value.Date;
					_existingPayment.client_id = clientId;

					await _paymentService.UpdatePayment(_existingPayment);
					MessageBox.Show("Payment updated successfully!");
				}

				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}
		}

		private async void nameClientCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (_loadingClients || _existingPayment != null)
					return;

				if (nameClientCombo.SelectedValue is int clientId)
				{
					using (var context = DbContext.CreateDbContext())
					{
						var clientService = new ClientServices(context);
						var client = await clientService.GetClientById(clientId);

						if (client != null)
						{
							var package = await clientService.GetPackageById(client.pack_id);
							if (package != null)
							{
								AmountTxt.Text = package.pack_price.ToString("0.00");
								AmountTxt.ReadOnly = true;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error loading package price: {ex.Message}");
			}
		}
	}
}
