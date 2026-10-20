using GymData.Models;
using GymData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymServices.Dtos;

namespace GymServices
{
   public class ClientServices
    {
		private readonly GymContextDB _context;

		public ClientServices(GymContextDB context)
		{
			_context = context;
		}


		public async Task<List<ClientDto>> GetAllClients()
		{
			var clients = await _context.client
			   .Include(c => c.Package)
			   .Include(c => c.Payments)
			   .ToListAsync();

			return clients.Select(s =>
			{
				var invoice = Membership.CyclePayment(s);
				int months = s.BillingMonths <= 0 ? 1 : s.BillingMonths;
				return new ClientDto
				{
					Id = s.client_id,
					Name = s.client_name,
					Gender = s.client_gender,
					BirthDate = s.dateofBirth,
					Phone = s.phone,
					StartDate = s.startDate,
					EndDate = s.endDate,
					PackageTitle = s.Package != null ? s.Package.pack_title : "No package",
					Cycle = BillingCycle.Label(months),
					PaymentStatus = Membership.Status(s),
					PaymentsAmount = invoice == null ? "" : invoice.amount.ToString("0.00"),
					PaymentType = invoice?.payment_type ?? ""
				};
			}).ToList();
		} 
		public async Task<Client> AddClient(Client client)
		{
			if (client == null)
				throw new ArgumentNullException(nameof(client));
			await _context.client.AddAsync(client);
			await _context.SaveChangesAsync();
			return client;
		}
		public (int Packages, int ActiveMemberships, decimal MonthRevenue) GetOverview()
		{
			var today = DateTime.Today;
			var monthStart = new DateTime(today.Year, today.Month, 1);
			int packages = _context.package.Count();
			var clients = _context.client.Include(c => c.Payments).ToList();
			int active = clients.Count(c => Membership.Status(c) == "Active");
			decimal revenue = _context.payment
				.Where(p => p.payment_status == "Paid" && p.created_at >= monthStart && p.created_at < monthStart.AddMonths(1))
				.Select(p => (decimal?)p.amount)
				.Sum() ?? 0;
			return (packages, active, revenue);
		}

		public async Task<List<Package>> GetAllPackages()
		{
			return await _context.package.ToListAsync();
		}
		public async Task<Package?> GetPackageById(int id)
		{
			return await _context.package.FindAsync(id);
		}
		public async Task<Client?> GetClientById(int id)
		{
			return await _context.client
				.Include(c => c.Package)
				.Include(c => c.Payments)
				.FirstOrDefaultAsync(c => c.client_id == id);
		}

		public async Task DeleteClient(int id)
		{
			var client = await _context.client.FindAsync(id);
			if (client != null)
			{
				_context.client.Remove(client);
				await _context.SaveChangesAsync();
			}
		}
		public async Task UpdateClient(Client client)
		{
			var existing = await _context.client.FirstOrDefaultAsync(c => c.client_id == client.client_id);
			if (existing == null)
				throw new InvalidOperationException("Client not found.");

			existing.client_name = client.client_name.Trim();
			existing.client_gender = client.client_gender;
			existing.dateofBirth = client.dateofBirth;
			existing.phone = client.phone.Trim();
			existing.startDate = client.startDate;
			existing.endDate = client.endDate;
			existing.BillingMonths = client.BillingMonths <= 0 ? 1 : client.BillingMonths;
			existing.pack_id = client.pack_id;
			existing.ispaid = client.ispaid;
			await _context.SaveChangesAsync();
		}
	}
}
