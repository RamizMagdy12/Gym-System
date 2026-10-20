using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymServices.Dtos
{
    public class PackageInfoDTO
    {
        public string PackageName { get; set; } = string.Empty;
        public string InstructorName { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
    }
}
