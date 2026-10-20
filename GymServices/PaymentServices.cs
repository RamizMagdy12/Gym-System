using GymData.Models;
using GymData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymServices
{
   public class PaymentServices
    {
		private readonly GymContextDB _context;

		public PaymentServices(GymContextDB context)
		{
			_context = context;
		}

		public async Task<List<Payment>> GetAllPayments()
		{
			return await _context.payment
				.Include(p => p.Client)
					.ThenInclude(c => c!.Package)
				.ToListAsync();
		}

		public async Task AddPayment(Payment payment)
		{
			throw new InvalidOperationException("Payments are created from the client subscription. Collect the invoice instead of typing a new amount.");
		}

		public async Task EnsureAllCyclePayments()
		{
			var clients = await _context.client.Include(c => c.Package).ToListAsync();
			foreach (var client in clients)
			{
				int months = client.BillingMonths <= 0 ? 1 : client.BillingMonths;
				decimal amount = client.Package == null
					? 0
					: BillingCycle.PriceFor(client.Package.pack_price, client.Package.DurationMonths, months);
				await EnsureCyclePayment(client.client_id, client.startDate, client.endDate, amount);
			}
		}

		public async Task EnsureCyclePayment(int clientId, DateTime start, DateTime end, decimal amount)
		{
			var existing = await _context.payment.FirstOrDefaultAsync(p =>
				p.client_id == clientId &&
				p.created_at >= start.Date &&
				p.created_at < end.Date);

			if (existing == null)
			{
				_context.payment.Add(new Payment
				{
					client_id = clientId,
					amount = amount,
					payment_type = "Cash",
					payment_status = "Pending",
					created_at = start.Date
				});
			}
			else if (!string.Equals(existing.payment_status, "Paid", StringComparison.OrdinalIgnoreCase))
			{
				existing.amount = amount;
				existing.created_at = start.Date;
			}

			await _context.SaveChangesAsync();
			await SyncPaidFlag(clientId);
		}

		public async Task MarkPaid(int paymentId, string method)
		{
			var payment = await _context.payment.FirstOrDefaultAsync(p => p.payment_id == paymentId);
			if (payment == null)
				throw new InvalidOperationException("Payment not found.");

			if (string.Equals(payment.payment_status, "Paid", StringComparison.OrdinalIgnoreCase))
				throw new InvalidOperationException("This subscription is already paid.");

			payment.payment_status = "Paid";
			payment.payment_type = string.IsNullOrWhiteSpace(method) ? "Cash" : method.Trim();
			await _context.SaveChangesAsync();
			await SyncPaidFlag(payment.client_id);
		}

		private async Task SyncPaidFlag(int clientId)
		{
			var client = await _context.client.FirstOrDefaultAsync(c => c.client_id == clientId);
			if (client == null)
				return;

			bool paid = await _context.payment.AnyAsync(p =>
				p.client_id == clientId &&
				p.payment_status == "Paid" &&
				p.created_at >= client.startDate.Date &&
				p.created_at < client.endDate.Date);

			client.ispaid = paid;
			await _context.SaveChangesAsync();
		}
		public async Task<Payment?> GetPaymentById(int id)
		{
			return await _context.payment
				.Include(p => p.Client)
					.ThenInclude(c => c!.Package)
				.FirstOrDefaultAsync(p => p.payment_id == id);
		}

		public async Task DeletePayment(int id)
		{
			var payment = await _context.payment.FindAsync(id);
			if (payment != null)
			{
				int clientId = payment.client_id;
				_context.payment.Remove(payment);
				await _context.SaveChangesAsync();
				await SyncPaidFlag(clientId);
			}
		}
		public async Task UpdatePayment(Payment payment)
		{
			var existing = await _context.payment.FirstOrDefaultAsync(p => p.payment_id == payment.payment_id);
			if (existing == null)
				throw new InvalidOperationException("Payment not found.");

			existing.payment_type = payment.payment_type;
			existing.amount = payment.amount;
			existing.payment_status = payment.payment_status;
			existing.created_at = payment.created_at;
			existing.client_id = payment.client_id;
			await _context.SaveChangesAsync();
			await SyncPaidFlag(existing.client_id);
		}
	}
}

