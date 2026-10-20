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
	public partial class EmployeeForm : Form
	{
		private readonly EmployeeServices _employeeService;
		private List<Employee> _employees = new();

		public EmployeeForm()
		{
			InitializeComponent();
			var context = DbContext.CreateDbContext();
			_employeeService = new EmployeeServices(context);
		}
		private async Task LoadEmployees()
		{
			try
			{
				_employees = await _employeeService.GetAll();
				BindEmployees(_employees);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error loading employees: " + ex.Message);
			}
		}

		private void BindEmployees(IEnumerable<Employee> employees)
		{
			EmployeeData.DataSource = employees.ToList();
			if (EmployeeData.Columns.Contains("rep_pass"))
				EmployeeData.Columns["rep_pass"].Visible = false;
		}
		private async void Addbtn_Click(object sender, EventArgs e)
		{
			AddEmployee addForm = new AddEmployee();
			addForm.ShowDialog();
			await LoadEmployees();
		}

		private async void EmployeeForm_Load(object sender, EventArgs e)
		{
			await LoadEmployees();
		}

		private async void Deletebtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (EmployeeData.SelectedRows.Count == 0)
				{
					MessageBox.Show("Please select an employee to delete.");
					return;
				}

				int employeeId = Convert.ToInt32(EmployeeData.SelectedRows[0].Cells["rep_id"].Value);

				var confirm = MessageBox.Show("Are you sure you want to delete this employee?",
											  "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (confirm == DialogResult.Yes)
				{
					bool deleted = await _employeeService.Delete(employeeId);

					if (deleted)
					{
						await LoadEmployees();
						MessageBox.Show("Employee deleted successfully ✅");
					}
					else
					{
						MessageBox.Show("Employee not found!");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}
		}

		private async void Updatebtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (EmployeeData.SelectedRows.Count == 0)
				{
					MessageBox.Show("Please select an employee to update.");
					return;
				}

				int employeeId = Convert.ToInt32(EmployeeData.SelectedRows[0].Cells["rep_id"].Value);

			
				var employee = await _employeeService.GetById(employeeId);
				if (employee == null)
				{
					MessageBox.Show("Employee not found.");
					return;
				}

				
				AddEmployee updateForm = new AddEmployee(employee);
				updateForm.ShowDialog();

				
				await LoadEmployees();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}

		}
		private void SearchTxt_TextChanged(object sender, EventArgs e)
		{
			string searchedText = SearchTxt.Text.Trim();
			IEnumerable<Employee> filtered = _employees;
			if (!string.IsNullOrWhiteSpace(searchedText))
			{
				filtered = _employees.Where(emp =>
					(emp.rep_name ?? "").StartsWith(searchedText, StringComparison.OrdinalIgnoreCase)
					|| (emp.user_name ?? "").StartsWith(searchedText, StringComparison.OrdinalIgnoreCase)
					|| (emp.rep_phone ?? "").Contains(searchedText));
			}

			BindEmployees(filtered);
		}
	}
}
