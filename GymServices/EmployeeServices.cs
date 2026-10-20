using GymData;
using GymData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymServices
{
   public class EmployeeServices
    {
		private readonly GymContextDB _context;
		public EmployeeServices(GymContextDB context)
		{
			_context = context;
		}

		public async  Task<List<Employee>> GetAll()
		{
			return await _context.employees.ToListAsync();
		}
		public async Task<Employee> Add(Employee employee)
		{
			await _context.employees.AddAsync(employee);
			await _context.SaveChangesAsync();
			return employee;
		}
		public async Task<bool> IsUsernameTaken(string username, int? excludeId = null)
		{
			var normalized = username.Trim();
			return await _context.employees.AnyAsync(e =>
				e.user_name == normalized && (excludeId == null || e.rep_id != excludeId));
		}

		public async Task<bool> Delete(int rep_id)
		{
			var employee = await _context.employees.FindAsync(rep_id);
			if (employee == null)
				return false;

			bool hasFinance = await _context.FinanceRecords.AnyAsync(f => f.EmployeeId == rep_id);
			if (hasFinance)
				throw new InvalidOperationException("This employee has finance records and cannot be deleted.");

			_context.employees.Remove(employee);
			await _context.SaveChangesAsync();
			return true;
		}
		public async Task<Employee?> GetById(int id)
		{
			return await _context.employees.FirstOrDefaultAsync(e => e.rep_id == id);
		}
		public async Task<bool> Update(Employee emp)
		{
			if (emp == null)
				return false;

			var existing = await _context.employees.FirstOrDefaultAsync(e => e.rep_id == emp.rep_id);
			if (existing == null)
				return false;

			existing.user_name = emp.user_name;
			existing.role = emp.role;
			existing.rep_name = emp.rep_name;
			existing.rep_gender = emp.rep_gender;
			existing.rep_birthDate = emp.rep_birthDate;
			existing.rep_address = emp.rep_address;
			existing.rep_phone = emp.rep_phone;
			existing.rep_pass = emp.rep_pass;
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
