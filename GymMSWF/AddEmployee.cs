using GymData.Models;
using GymMSWF;
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
using System.Xml.Linq;

namespace GymMSWF
{
	public partial class AddEmployee : Form
	{
		private readonly EmployeeServices _employeeService;
		private readonly Employee? _existingEmployee;

		public AddEmployee(Employee? employee = null)
		{
			InitializeComponent();

			var context = DbContext.CreateDbContext();
			_employeeService = new EmployeeServices(context);
			var roleNames = new RoleService(context).GetRoleNames();
			if (roleNames.Count > 0)
			{
				RoleCombo.Items.Clear();
				RoleCombo.Items.AddRange(roleNames.Cast<object>().ToArray());
			}

			_existingEmployee = employee;

			if (_existingEmployee != null)
			{
				LoadEmployeeData();
				Addbtn.Text = "Update";
				Addbtn.BackColor = ColorTranslator.FromHtml("#00BCD4");
			}
		}

		private void LoadEmployeeData()
		{
			nameTxt.Text = _existingEmployee.rep_name;
			PhoneTxt.Text = _existingEmployee.rep_phone;
			AddressTxt.Text = _existingEmployee.rep_address;
			genderCombo.SelectedItem = _existingEmployee.rep_gender;
			DataOfBTime.Value = _existingEmployee.rep_birthDate;
			UserNameTxt.Text = _existingEmployee.user_name;
			PasswordTxt.Text = _existingEmployee.rep_pass;
			RoleCombo.SelectedItem = _existingEmployee.role;
		}

		private bool TryReadEmployee(out string name, out string phone, out string address, out string gender, out string username, out string password, out string role)
		{
			name = nameTxt.Text.Trim();
			phone = PhoneTxt.Text.Trim();
			address = AddressTxt.Text.Trim();
			gender = genderCombo.SelectedItem?.ToString() ?? string.Empty;
			username = UserNameTxt.Text.Trim();
			password = PasswordTxt.Text;
			role = RoleCombo.SelectedItem?.ToString() ?? string.Empty;

			if (string.IsNullOrWhiteSpace(name))
			{
				MessageBox.Show("Please enter the employee name.");
				return false;
			}

			if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{8,15}$"))
			{
				MessageBox.Show("Phone number must contain only digits (8–15 digits).");
				return false;
			}

			if (string.IsNullOrWhiteSpace(address))
			{
				MessageBox.Show("Please enter the address.");
				return false;
			}

			if (string.IsNullOrWhiteSpace(gender))
			{
				MessageBox.Show("Please select a gender.");
				return false;
			}

			if (string.IsNullOrWhiteSpace(username))
			{
				MessageBox.Show("Please enter a username.");
				return false;
			}

			if (string.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("Please enter a password.");
				return false;
			}

			if (string.IsNullOrWhiteSpace(role))
			{
				MessageBox.Show("Please select a role.");
				return false;
			}

			return true;
		}

		private async void Addbtn_Click(object sender, EventArgs e)
		{
			if (!TryReadEmployee(out string name, out string phone, out string address, out string gender, out string username, out string password, out string role))
				return;

			try
			{
				int? currentId = _existingEmployee?.rep_id;
				if (await _employeeService.IsUsernameTaken(username, currentId))
				{
					MessageBox.Show("This username is already used by another employee.");
					return;
				}

				if (_existingEmployee != null)
				{
					_existingEmployee.rep_name = name;
					_existingEmployee.rep_phone = phone;
					_existingEmployee.rep_address = address;
					_existingEmployee.rep_gender = gender;
					_existingEmployee.rep_birthDate = DataOfBTime.Value;
					_existingEmployee.user_name = username;
					_existingEmployee.rep_pass = password;
					_existingEmployee.role = role;

					bool updated = await _employeeService.Update(_existingEmployee);
					MessageBox.Show(updated
						? "Employee updated successfully!"
						: "Update failed! Employee not found.");
				}
				else
				{
					var emp = new Employee
					{
						rep_name = name,
						rep_phone = phone,
						rep_address = address,
						rep_gender = gender,
						rep_birthDate = DataOfBTime.Value,
						user_name = username,
						rep_pass = password,
						role = role
					};

					await _employeeService.Add(emp);
					MessageBox.Show("Employee added successfully!");
				}

				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}
		}
	}
}



