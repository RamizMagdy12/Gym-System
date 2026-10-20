using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData.Models
{
    public class Employee
    {
        [Key]
        public int rep_id { get; set; }

        public  string  user_name { get; set; }
        public string role { get; set; }
        public string rep_name { get; set; } = string.Empty;
        public string rep_gender { get; set; } = string.Empty;
        public DateTime rep_birthDate { get; set; }
        public string rep_address { get; set; } = string.Empty;
        public string rep_phone { get; set; } = string.Empty;
        public string rep_pass { get; set; } = string.Empty;
    }
}
