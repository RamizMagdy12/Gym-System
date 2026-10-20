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
	public partial class AddClient : Form
	{
		private readonly ClientServices _clientService;
		private readonly PaymentServices _paymentService;
		private readonly Client? _existingClient;
		private readonly ComboBox _cycleCombo = new ComboBox();
		private List<Package> _packages = new();
		private bool _loadingClient;

		public AddClient(Client? client = null)
		{
			InitializeComponent();

			var context = DbContext.CreateDbContext();
			_clientService = new ClientServices(context);
			_paymentService = new PaymentServices(context);

			_existingClient = client;
			BuildCycleSelector();
			LoadPackages();

            if (_existingClient != null)
            {
                LoadClientData();
                Addbtn.Text = "Update";
                Addbtn.FillColor = ColorTranslator.FromHtml("#00BCD4");

            }
        }
		private void LoadClientData()
		{
			nameTxt.Text = _existingClient.client_name;
			genderCombo.SelectedItem = _existingClient.client_gender;
			DataOfBTime.Value = _existingClient.dateofBirth;
			phoneTxt.Text = _existingClient.phone;
			startDateTime.Value = _existingClient.startDate;
			_cycleCombo.SelectedValue = _existingClient.BillingMonths <= 0 ? 1 : _existingClient.BillingMonths;
			ApplyCycle();
		}

		private void BuildCycleSelector()
		{
			_cycleCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			_cycleCombo.FlatStyle = FlatStyle.Flat;
			_cycleCombo.BackColor = Color.FromArgb(47, 61, 71);
			_cycleCombo.ForeColor = Color.White;
			_cycleCombo.Font = new Font("Segoe UI", 10F);
			_cycleCombo.Location = new Point(155, 348);
			_cycleCombo.Size = new Size(406, 36);
			_cycleCombo.DataSource = BillingCycle.Options.Select(months => new CycleChoice(months, BillingCycle.Label(months))).ToList();
			_cycleCombo.DisplayMember = nameof(CycleChoice.Label);
			_cycleCombo.ValueMember = nameof(CycleChoice.Months);
			_cycleCombo.SelectedIndexChanged += (_, _) => ApplyCycle();
			startDateTime.ValueChanged += (_, _) => ApplyCycle();
			packagecombo.SelectedIndexChanged += (_, _) => ApplyPackageCycle();
			endDateTime.Enabled = false;

			Controls.Add(new Label
			{
				Text = "Cycle",
				ForeColor = Color.White,
				Font = new Font("Segoe UI", 11F, FontStyle.Bold),
				Location = new Point(40, 354),
				AutoSize = true
			});
			Controls.Add(_cycleCombo);
			_cycleCombo.BringToFront();
		}

		private void ApplyPackageCycle()
		{
			if (_loadingClient)
				return;

			var package = SelectedPackage();
			if (package == null)
				return;

			_cycleCombo.SelectedValue = package.DurationMonths <= 0 ? 1 : package.DurationMonths;
			ApplyCycle();
		}

		private void ApplyCycle()
		{
			if (_loadingClient || _cycleCombo.SelectedValue is not int months)
				return;

			var end = BillingCycle.EndDate(startDateTime.Value, months);
			if (end < endDateTime.MinDate)
				end = endDateTime.MinDate;
			if (end > endDateTime.MaxDate)
				end = endDateTime.MaxDate;
			endDateTime.Value = end;
		}

		private Package? SelectedPackage()
		{
			if (packagecombo.SelectedValue == null || !int.TryParse(packagecombo.SelectedValue.ToString(), out int packageId))
				return null;

			return _packages.FirstOrDefault(p => p.pack_id == packageId);
		}

		private int SelectedMonths()
		{
			return _cycleCombo.SelectedValue is int months && months > 0 ? months : 1;
		}

		private async void LoadPackages()
		{
			try
			{
				_loadingClient = true;
				_packages = await _clientService.GetAllPackages();
				packagecombo.DataSource = _packages;
				packagecombo.DisplayMember = "pack_title";
				packagecombo.ValueMember = "pack_id";
				if (_existingClient != null)
					packagecombo.SelectedValue = _existingClient.pack_id;
				else
					packagecombo.SelectedIndex = _packages.Count > 0 ? 0 : -1;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not load packages: " + ex.Message);
			}
			finally
			{
				_loadingClient = false;
				if (_existingClient == null)
					ApplyPackageCycle();
				else
				{
					_cycleCombo.SelectedValue = _existingClient.BillingMonths <= 0 ? 1 : _existingClient.BillingMonths;
					ApplyCycle();
				}
			}
		}

		private bool TryReadClient(out string name, out string gender, out string phone, out int packageId)
		{
			name = nameTxt.Text.Trim();
			gender = genderCombo.SelectedItem?.ToString() ?? string.Empty;
			phone = phoneTxt.Text.Trim();
			packageId = 0;

			if (string.IsNullOrWhiteSpace(name))
			{
				MessageBox.Show("Please enter the client name.");
				return false;
			}

			if (string.IsNullOrWhiteSpace(gender))
			{
				MessageBox.Show("Please select a gender.");
				return false;
			}

			if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{8,15}$"))
			{
				MessageBox.Show("Phone number must contain only digits (8–15 digits).");
				return false;
			}

			if (endDateTime.Value.Date < startDateTime.Value.Date)
			{
				MessageBox.Show("End date cannot be earlier than the start date.");
				return false;
			}

			if (packagecombo.SelectedValue == null || !int.TryParse(packagecombo.SelectedValue.ToString(), out packageId))
			{
				MessageBox.Show("Please select a package.");
				return false;
			}

			return true;
		}

		private async void Addbtn_Click(object sender, EventArgs e)
		{
			if (!TryReadClient(out string name, out string gender, out string phone, out int packageId))
				return;

			try
			{
				var package = SelectedPackage();
				int months = SelectedMonths();
				var start = startDateTime.Value.Date;
				var end = BillingCycle.EndDate(start, months);
				decimal amount = package == null
					? 0
					: BillingCycle.PriceFor(package.pack_price, package.DurationMonths, months);

				Client saved;
				if (_existingClient != null)
				{
					_existingClient.client_name = name;
					_existingClient.client_gender = gender;
					_existingClient.dateofBirth = DataOfBTime.Value;
					_existingClient.phone = phone;
					_existingClient.startDate = start;
					_existingClient.endDate = end;
					_existingClient.BillingMonths = months;
					_existingClient.pack_id = packageId;

					await _clientService.UpdateClient(_existingClient);
					saved = _existingClient;
				}
				else
				{
					saved = new Client
					{
						client_name = name,
						client_gender = gender,
						dateofBirth = DataOfBTime.Value,
						phone = phone,
						startDate = start,
						endDate = end,
						BillingMonths = months,
						pack_id = packageId
					};

					await _clientService.AddClient(saved);
				}

				await _paymentService.EnsureCyclePayment(saved.client_id, start, end, amount);

				MessageBox.Show(
					$"Client saved.\n{BillingCycle.Label(months)} is locked from {start:dd MMM yyyy} to {end:dd MMM yyyy}.\nInvoice: ${amount:0.00}. Collect it from Payments. Do not type the amount again.");
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not save the client: " + ex.Message);
			}
		}
	}
	}

