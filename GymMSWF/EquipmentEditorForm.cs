using GymData.Models;
using GymServices;

namespace GymMSWF
{
	public class EquipmentEditorForm : Form
	{
		private readonly EquipmentService _equipmentService;
		private readonly EmployeeServices _employeeService;
		private readonly Equipment? _existing;

		private readonly TextBox _name = new();
		private readonly TextBox _category = new();
		private readonly TextBox _description = new();
		private readonly NumericUpDown _quantity = new();
		private readonly NumericUpDown _price = new();
		private readonly ComboBox _condition = new();
		private readonly DateTimePicker _purchaseDate = new();
		private readonly DateTimePicker _maintenanceDate = new();
		private readonly CheckBox _hasMaintenance = new();
		private readonly CheckBox _available = new();
		private readonly ComboBox _employee = new();

		public EquipmentEditorForm(Equipment? equipment = null)
		{
			_existing = equipment;
			var context = DbContext.CreateDbContext();
			_equipmentService = new EquipmentService(context);
			_employeeService = new EmployeeServices(context);

			Text = equipment == null ? "Add equipment" : "Edit equipment";
			FormBorderStyle = FormBorderStyle.FixedDialog;
			StartPosition = FormStartPosition.CenterParent;
			MaximizeBox = false;
			MinimizeBox = false;
			ClientSize = new Size(460, 520);
			BackColor = Color.FromArgb(47, 61, 71);
			ForeColor = Color.White;
			Font = new Font("Segoe UI", 10F);

			BuildLayout();
			Load += async (_, _) => await LoadFormAsync();
		}

		private void BuildLayout()
		{
			var layout = new TableLayoutPanel
			{
				Dock = DockStyle.Fill,
				ColumnCount = 2,
				Padding = new Padding(16),
				BackColor = Color.FromArgb(47, 61, 71)
			};
			layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
			layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

			_quantity.Maximum = 100000;
			_price.DecimalPlaces = 2;
			_price.Maximum = 1000000;
			_price.ThousandsSeparator = true;
			_condition.DropDownStyle = ComboBoxStyle.DropDownList;
			_condition.Items.AddRange(new object[] { "New", "Good", "Fair", "Needs repair", "Out of service" });
			_purchaseDate.Format = DateTimePickerFormat.Short;
			_maintenanceDate.Format = DateTimePickerFormat.Short;
			_hasMaintenance.Text = "Schedule maintenance";
			_hasMaintenance.ForeColor = Color.White;
			_available.Text = "Available";
			_available.ForeColor = Color.White;
			_available.Checked = true;
			_employee.DropDownStyle = ComboBoxStyle.DropDownList;

			AddRow(layout, "Name", _name);
			AddRow(layout, "Category", _category);
			AddRow(layout, "Quantity", _quantity);
			AddRow(layout, "Price", _price);
			AddRow(layout, "Condition", _condition);
			AddRow(layout, "Purchase date", _purchaseDate);
			AddRow(layout, "", _hasMaintenance);
			AddRow(layout, "Maintenance", _maintenanceDate);
			AddRow(layout, "", _available);
			AddRow(layout, "Employee", _employee);
			AddRow(layout, "Description", _description);
			_description.Multiline = true;
			_description.Height = 70;

			var save = new Button
			{
				Text = "Save",
				Dock = DockStyle.Fill,
				BackColor = Color.FromArgb(74, 169, 81),
				ForeColor = Color.White,
				FlatStyle = FlatStyle.Flat,
				Height = 36
			};
			save.Click += async (_, _) => await SaveAsync();

			var cancel = new Button
			{
				Text = "Cancel",
				Dock = DockStyle.Right,
				Width = 100,
				BackColor = Color.FromArgb(52, 66, 76),
				ForeColor = Color.White,
				FlatStyle = FlatStyle.Flat
			};
			cancel.Click += (_, _) => Close();

			var buttons = new FlowLayoutPanel
			{
				FlowDirection = FlowDirection.RightToLeft,
				Dock = DockStyle.Fill,
				Height = 40
			};
			buttons.Controls.Add(save);
			buttons.Controls.Add(cancel);
			save.Width = 100;

			AddRow(layout, "", buttons);
			Controls.Add(layout);
		}

		private static void AddRow(TableLayoutPanel layout, string label, Control input)
		{
			int row = layout.RowCount++;
			layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
			var caption = new Label
			{
				Text = label,
				AutoSize = true,
				ForeColor = Color.White,
				Margin = new Padding(0, 8, 8, 0)
			};
			input.Margin = new Padding(0, 4, 0, 4);
			input.Dock = DockStyle.Fill;
			layout.Controls.Add(caption, 0, row);
			layout.Controls.Add(input, 1, row);
		}

		private async Task LoadFormAsync()
		{
			try
			{
				var employees = await _employeeService.GetAll();
				var options = new List<EmployeeOption> { new(null, "Unassigned") };
				options.AddRange(employees.Select(e => new EmployeeOption(e.rep_id, e.rep_name)));
				_employee.DataSource = options;
				_employee.DisplayMember = nameof(EmployeeOption.Name);

				if (_existing == null)
				{
					_condition.SelectedIndex = 0;
					return;
				}

				_name.Text = _existing.EquipName;
				_category.Text = _existing.Category;
				_description.Text = _existing.EquipDescription;
				_quantity.Value = Math.Clamp(_existing.Quantity, 0, (int)_quantity.Maximum);
				_price.Value = Math.Clamp(_existing.Price, 0, _price.Maximum);
				if (!_condition.Items.Contains(_existing.Condition))
					_condition.Items.Add(_existing.Condition);
				_condition.SelectedItem = _existing.Condition;
				_purchaseDate.Value = _existing.PurchaseDate == default ? DateTime.Today : _existing.PurchaseDate;
				_hasMaintenance.Checked = _existing.MaintenanceDate.HasValue;
				if (_existing.MaintenanceDate.HasValue)
					_maintenanceDate.Value = _existing.MaintenanceDate.Value;
				_available.Checked = _existing.IsAvailable;

				var match = options.FirstOrDefault(o => o.Id == _existing.EmployeeId) ?? options[0];
				_employee.SelectedItem = match;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not open equipment: " + ex.Message);
				Close();
			}
		}

		private async Task SaveAsync()
		{
			string name = _name.Text.Trim();
			string category = _category.Text.Trim();
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category))
			{
				MessageBox.Show("Name and category are required.");
				return;
			}

			if (_condition.SelectedItem == null)
			{
				MessageBox.Show("Please select a condition.");
				return;
			}

			var selectedEmployee = _employee.SelectedItem as EmployeeOption;
			var equipment = new Equipment
			{
				EquipmentId = _existing?.EquipmentId ?? 0,
				EquipName = name,
				Category = category,
				EquipDescription = _description.Text.Trim(),
				Quantity = (int)_quantity.Value,
				Price = _price.Value,
				Condition = _condition.SelectedItem.ToString() ?? "Good",
				PurchaseDate = _purchaseDate.Value.Date,
				MaintenanceDate = _hasMaintenance.Checked ? _maintenanceDate.Value.Date : null,
				IsAvailable = _available.Checked,
				EmployeeId = selectedEmployee?.Id
			};

			try
			{
				if (_existing == null)
					_equipmentService.Add(equipment);
				else
					_equipmentService.Update(equipment);

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not save equipment: " + ex.Message);
			}
		}

		private sealed record EmployeeOption(int? Id, string Name);
	}
}
