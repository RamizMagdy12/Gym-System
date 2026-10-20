using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymServices.Dtos
{
    public class ClientAttendanceSummaryDTO
    {
        public string ClientName { get; set; }
        public string PackageName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalSessions { get; set; }
        public int AttendedSessions { get; set; }
        public int RemainingSessions => TotalSessions - AttendedSessions;
        public DateTime? LastAttendanceDate { get; set; }
        public DateTime CurrentAttendanceTime { get; set; } = DateTime.Now;
    }
}
