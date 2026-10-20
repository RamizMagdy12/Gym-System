using GymData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymServices.Dtos
{
   public class ClientDto
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Gender { get; set; }
		public DateTime BirthDate { get; set; }
		public string Phone { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string PackageTitle { get; set; }
		public string Cycle { get; set; } = string.Empty;

		public string PaymentStatus { get; set; }
		
		public string PaymentsAmount { get; set; } = string.Empty;
		public string PaymentType { get; set; } = string.Empty;

	}
}
