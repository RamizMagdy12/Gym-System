using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData.Models
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }

        public string EquipName { get; set; } = string.Empty;

        public string EquipDescription { get; set; } = string.Empty;

        public string? EquipImage { get; set; }

        public string Category { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public string Condition { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = true;

        public DateTime? MaintenanceDate { get; set; } = DateTime.Now;

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
