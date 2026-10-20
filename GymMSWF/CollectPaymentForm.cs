using GymData.Models;
using GymServices;

namespace GymMSWF
{
	public class CollectPaymentForm : Form
	{
		private readonly ComboBox _method = new ComboBox();

		public string Method => _method.SelectedItem?.ToString() ?? "Cash";

		public CollectPaymentForm(Payment payment)
		{
			var client = payment.Client;
			int months = client == null || client.BillingMonths <= 0 ? 1 : client.BillingMonths;
			string period = client == null
				? payment.created_at.ToString("dd MMM yyyy")
				: $"{client.startDate:dd MMM yyyy}  →  {client.endDate:dd MMM yyyy}";

			Text = "Collect payment";
			FormBorderStyle = FormBorderStyle.FixedDialog;
			StartPosition = FormStartPosition.CenterParent;
			MaximizeBox = false;
			MinimizeBox = false;
			ClientSize = new Size(460, 420);
			BackColor = Color.FromArgb(47, 61, 71);
			ForeColor = Color.White;
			Font = new Font("Segoe UI", 10F);

			Controls.Add(Line("Client", client?.client_name ?? "N/A", 24));
			Controls.Add(Line("Package", client?.Package?.pack_title ?? "No package", 84));
			Controls.Add(Line("Cycle", BillingCycle.Label(months), 144));
			Controls.Add(Line("Period", period, 204));
			Controls.Add(Line("Amount", $"${payment.amount:0.00}", 264));

			Controls.Add(new Label
			{
				Text = "Method",
				ForeColor = Color.White,
				Font = new Font("Segoe UI", 10F, FontStyle.Bold),
				Location = new Point(28, 324),
				AutoSize = true
			});

			_method.DropDownStyle = ComboBoxStyle.DropDownList;
			_method.FlatStyle = FlatStyle.Flat;
			_method.BackColor = Color.FromArgb(36, 48, 56);
			_method.ForeColor = Color.White;
			_method.Location = new Point(150, 320);
			_method.Size = new Size(270, 32);
			_method.Items.AddRange(new object[] { "Cash", "Visa", "Card" });
			_method.SelectedItem = _method.Items.Contains(payment.payment_type) ? payment.payment_type : "Cash";
			Controls.Add(_method);

			var collect = new Button
			{
				Text = "Mark as paid",
				BackColor = Color.FromArgb(74, 169, 81),
				ForeColor = Color.White,
				FlatStyle = FlatStyle.Flat,
				Location = new Point(150, 364),
				Size = new Size(270, 40)
			};
			collect.FlatAppearance.BorderSize = 0;
			collect.Click += (_, _) =>
			{
				DialogResult = DialogResult.OK;
				Close();
			};
			Controls.Add(collect);
			AcceptButton = collect;
		}

		private static Control Line(string caption, string value, int top)
		{
			var panel = new Panel
			{
				Location = new Point(28, top),
				Size = new Size(404, 52),
				BackColor = Color.Transparent
			};
			panel.Controls.Add(new Label
			{
				Text = caption,
				ForeColor = Color.FromArgb(160, 170, 190),
				Font = new Font("Segoe UI", 9F),
				Location = new Point(0, 0),
				AutoSize = true
			});
			panel.Controls.Add(new Label
			{
				Text = value,
				ForeColor = Color.White,
				Font = new Font("Segoe UI", 12F, FontStyle.Bold),
				Location = new Point(0, 22),
				AutoSize = true
			});
			return panel;
		}
	}
}
