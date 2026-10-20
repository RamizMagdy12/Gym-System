using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData.Models
{
    public class Package
    {
        [Key]
        public int pack_id { get; set; }

        public int? ins_id { get; set; }
        public string pack_title { get; set; } = string.Empty;
        public decimal pack_price { get; set; }
        public string pack_desc { get; set; } = string.Empty;
        public int pack_sessionsCount { get; set; }
        public int DurationMonths { get; set; } = 1;
        public string? pack_img { get; set; }

        
        public Instructor? Instructor { get; set; }
        public ICollection<Client> Members { get; set; } = new List<Client>();
    }
}
