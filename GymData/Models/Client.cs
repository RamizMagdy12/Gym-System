using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData.Models
{
    public class Client
    {
        [Key]
        public int client_id { get; set; }

        public int pack_id { get; set; }
        public bool ispaid { get; set; }
        public string client_name { get; set; } = string.Empty;
        public string client_gender { get; set; } = string.Empty;
        public DateTime dateofBirth { get; set; }
        public string phone { get; set; } = string.Empty;
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int BillingMonths { get; set; } = 1;

        public Package? Package { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
