using GymData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymServices
{
    public class FinanceService
    {
        private readonly GymContextDB _context;

        public FinanceService(GymContextDB context)
        {
            _context = context;
        }

        public (decimal Scheduled, decimal Paid, decimal Overdue) GetMonthlyFinanceSummary()
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1);

            var records = _context.FinanceRecords
                .Where(f => f.RecordDate >= startOfMonth && f.RecordDate < endOfMonth)
                .ToList();

            if (!records.Any())
                return (0, 0, 0);

            decimal totalScheduled = records.Sum(f => f.ScheduledAmount);
            decimal totalPaid = records.Sum(f => f.PaidAmount);
            decimal totalOverdue = Math.Max(0, totalScheduled - totalPaid);

            return (totalScheduled, totalPaid, totalOverdue);
        }

        public (decimal Scheduled, decimal Paid, decimal Overdue, string Period) GetPaymentMonthSummary()
        {
            var payments = _context.payment.ToList();
            if (payments.Count == 0)
                return (0, 0, 0, DateTime.Today.ToString("MMMM yyyy"));

            var startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var monthPayments = payments
                .Where(p => p.created_at >= startOfMonth && p.created_at < startOfMonth.AddMonths(1))
                .ToList();

            if (monthPayments.Count == 0)
            {
                var latest = payments.Max(p => p.created_at);
                startOfMonth = new DateTime(latest.Year, latest.Month, 1);
                monthPayments = payments
                    .Where(p => p.created_at >= startOfMonth && p.created_at < startOfMonth.AddMonths(1))
                    .ToList();
            }

            decimal scheduled = monthPayments.Sum(p => p.amount);
            decimal paid = monthPayments
                .Where(p => string.Equals(p.payment_status, "Paid", StringComparison.OrdinalIgnoreCase))
                .Sum(p => p.amount);
            decimal overdue = Math.Max(0, scheduled - paid);

            return (scheduled, paid, overdue, startOfMonth.ToString("MMMM yyyy"));
        }

        public decimal GetTodayPaid()
        {
            var today = DateTime.Today;
            return _context.FinanceRecords
                .Where(f => f.RecordDate.Date == today)
                .Sum(f => f.PaidAmount);
        }
    }
}
