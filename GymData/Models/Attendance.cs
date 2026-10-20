using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        public int MemberId { get; set; }
        public Client Client { get; set; }

        public DateTime AttendanceDate { get; set; } = DateTime.Now;
    }
}
