using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData.Models
{
    public class Payment
    {
        [Key]
        public int payment_id { get; set; }

        public string payment_type { get; set; } = string.Empty;
        public DateTime created_at { get; set; }
        public int client_id { get; set; }
        public decimal amount { get; set; }
        public string payment_status { get; set; } = string.Empty;

        public Client? Client { get; set; }
    }
}
