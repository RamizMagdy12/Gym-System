using GymData.Models;

namespace GymServices
{
	public static class Membership
	{
		public static Payment? CyclePayment(Client client)
		{
			var start = client.startDate.Date;
			var end = client.endDate.Date;
			return client.Payments
				.Where(p => p.created_at.Date >= start && p.created_at.Date < end)
				.OrderByDescending(p => string.Equals(p.payment_status, "Paid", StringComparison.OrdinalIgnoreCase))
				.ThenByDescending(p => p.payment_id)
				.FirstOrDefault();
		}

		public static bool IsCyclePaid(Client client)
		{
			var payment = CyclePayment(client);
			return payment != null && string.Equals(payment.payment_status, "Paid", StringComparison.OrdinalIgnoreCase);
		}

		public static string Status(Client client, DateTime? on = null)
		{
			var today = (on ?? DateTime.Today).Date;
			if (today >= client.endDate.Date)
				return "Expired";
			if (today < client.startDate.Date)
				return "Not started";
			return IsCyclePaid(client) ? "Active" : "Unpaid";
		}
	}
}
