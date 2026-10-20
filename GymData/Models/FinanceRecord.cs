using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData.Models
{
    public class FinanceRecord
    {
        [Key]
        public int FinanceId { get; set; }
        public DateTime RecordDate { get; set; } = DateTime.Now;
        public decimal ScheduledAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal OverdueAmount => ScheduledAmount - PaidAmount;
        public string? Notes { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
