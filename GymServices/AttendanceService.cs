using GymData;
using GymData.Models;
using GymServices.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GymServices
{
    public class AttendanceService
    {
        private readonly GymContextDB _context;

        public AttendanceService(GymContextDB context)
        {
            _context = context;
        }

        public int GetTodayAttendanceCount(DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1);

            return _context.Attendances
                .Count(a => a.AttendanceDate >= startOfDay && a.AttendanceDate < endOfDay);
        }

        public List<Attendance> GetLastAttendances(int count)
        {
            return _context.Attendances
                .Include(a => a.Client)
                    .ThenInclude(c => c.Package)
                .OrderByDescending(a => a.AttendanceDate)
                .Take(count)
                .ToList();
        }

        public Dictionary<int, int> GetAttendanceCounts(IEnumerable<int> clientIds)
        {
            var ids = clientIds.Distinct().ToList();
            if (ids.Count == 0)
                return new Dictionary<int, int>();

            var monthStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var monthEnd = monthStart.AddMonths(1);

            return _context.Attendances
                .Where(a => ids.Contains(a.MemberId)
                    && a.AttendanceDate >= monthStart
                    && a.AttendanceDate < monthEnd)
                .GroupBy(a => a.MemberId)
                .Select(g => new { ClientId = g.Key, Count = g.Count() })
                .ToDictionary(x => x.ClientId, x => x.Count);
        }

        public int GetAttendanceCountByClient(int clientId)
        {
            var monthStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var monthEnd = monthStart.AddMonths(1);
            return _context.Attendances.Count(a =>
                a.MemberId == clientId &&
                a.AttendanceDate >= monthStart &&
                a.AttendanceDate < monthEnd);
        }

        public (bool Success, string Message) CheckIn(int clientId)
        {
            var client = _context.client
                .Include(c => c.Package)
                .Include(c => c.Payments)
                .FirstOrDefault(c => c.client_id == clientId);

            if (client == null)
                return (false, "Client not found.");

			var today = DateTime.Today;
            if (client.Package == null)
                return (false, $"{client.client_name} is not subscribed. No package is assigned.");

            if (today >= client.endDate.Date)
                return (false, $"{client.client_name} is not subscribed. The package ended on {client.endDate:dd MMM yyyy}.");

            if (today < client.startDate.Date)
                return (false, $"{client.client_name} is not subscribed yet. The membership starts on {client.startDate:dd MMM yyyy}.");

            if (!Membership.IsCyclePaid(client))
                return (false, $"{client.client_name} is not subscribed. This cycle is not paid.");

            var monthStart = new DateTime(today.Year, today.Month, 1);
            var monthEnd = monthStart.AddMonths(1);
            int attendedThisMonth = _context.Attendances.Count(a =>
                a.MemberId == clientId &&
                a.AttendanceDate >= monthStart &&
                a.AttendanceDate < monthEnd);

            int allowed = client.Package?.pack_sessionsCount ?? 0;
            if (allowed > 0 && attendedThisMonth >= allowed)
                return (false, $"{client.client_name} has no sessions left this month.\nUsed {attendedThisMonth} of {allowed}. Remaining: 0.");

            bool alreadyToday = _context.Attendances.Any(a =>
                a.MemberId == clientId &&
                a.AttendanceDate >= today &&
                a.AttendanceDate < today.AddDays(1));

            if (alreadyToday)
                return (false, $"{client.client_name} is already checked in today.\nThis month: session {attendedThisMonth} of {SessionCap(allowed)}.\nRemaining: {RemainingText(allowed, attendedThisMonth)}.");

            _context.Attendances.Add(new Attendance
            {
                MemberId = clientId,
                AttendanceDate = DateTime.Now
            });
            _context.SaveChanges();

            int sessionNo = attendedThisMonth + 1;
            return (true, $"{client.client_name} checked in.\nThis is session {sessionNo} of {SessionCap(allowed)}.\nRemaining: {RemainingText(allowed, sessionNo)}.");
        }

        public List<AttendanceBoardItem> GetBoard()
        {
            var today = DateTime.Today;
            var monthStart = new DateTime(today.Year, today.Month, 1);
            var monthEnd = monthStart.AddMonths(1);
            var tomorrow = today.AddDays(1);

            var clients = _context.client
                .Include(c => c.Package)
                .Include(c => c.Payments)
                .ToList();

            var monthCounts = _context.Attendances
                .Where(a => a.AttendanceDate >= monthStart && a.AttendanceDate < monthEnd)
                .GroupBy(a => a.MemberId)
                .Select(g => new { Id = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Id, x => x.Count);

            var todayIds = _context.Attendances
                .Where(a => a.AttendanceDate >= today && a.AttendanceDate < tomorrow)
                .Select(a => a.MemberId)
                .ToHashSet();

            var lastVisits = _context.Attendances
                .GroupBy(a => a.MemberId)
                .Select(g => new { Id = g.Key, Last = g.Max(a => a.AttendanceDate) })
                .ToDictionary(x => x.Id, x => x.Last);

            return clients.Select(client =>
            {
                int attended = monthCounts.GetValueOrDefault(client.client_id);
                int allowed = client.Package?.pack_sessionsCount ?? 0;
                bool checkedToday = todayIds.Contains(client.client_id);
                string status = Membership.Status(client);
                string note = Describe(client, status, attended, allowed, checkedToday);
                bool canCheckIn = status == "Active" && !checkedToday && (allowed == 0 || attended < allowed);

                return new AttendanceBoardItem
                {
                    ClientId = client.client_id,
                    Name = client.client_name,
                    Phone = client.phone,
                    Package = client.Package?.pack_title ?? "No package",
                    Status = status,
                    AttendedThisMonth = attended,
                    AllowedSessions = allowed,
                    Remaining = RemainingText(allowed, attended),
                    LastVisit = lastVisits.TryGetValue(client.client_id, out var last) ? last.ToString("dd MMM yyyy  hh:mm tt") : "No visit",
                    CheckedInToday = checkedToday,
                    CanCheckIn = canCheckIn,
                    Note = note
                };
            })
            .OrderBy(x => x.Status == "Active" ? 0 : x.Status == "Unpaid" ? 1 : 2)
            .ThenBy(x => x.Name)
            .ToList();
        }

        public List<Attendance> GetTodayAttendances()
        {
            var today = DateTime.Today;
            return _context.Attendances
                .Include(a => a.Client)
                    .ThenInclude(c => c.Package)
                .Where(a => a.AttendanceDate >= today && a.AttendanceDate < today.AddDays(1))
                .OrderByDescending(a => a.AttendanceDate)
                .ToList();
        }

        private static string Describe(Client client, string status, int attended, int allowed, bool checkedToday)
        {
            if (status != "Active")
            {
                if (status == "Expired")
                    return $"{client.client_name} is not subscribed. The package ended on {client.endDate:dd MMM yyyy}.";
                if (status == "Not started")
                    return $"{client.client_name} is not subscribed yet. The membership starts on {client.startDate:dd MMM yyyy}.";
                if (client.Package == null)
                    return $"{client.client_name} is not subscribed. No package is assigned.";
                return $"{client.client_name} is not subscribed. This cycle is not paid.";
            }

            if (checkedToday)
                return $"Already checked in today.\nThis month: session {attended} of {SessionCap(allowed)}.\nRemaining: {RemainingText(allowed, attended)}.";

            if (allowed > 0 && attended >= allowed)
                return $"No sessions left this month.\nUsed {attended} of {allowed}. Remaining: 0.";

            int next = attended + 1;
            return $"Next check-in is session {next} of {SessionCap(allowed)}.\nRemaining after it: {RemainingText(allowed, next)}.";
        }

        private static string SessionCap(int allowed) => allowed <= 0 ? "unlimited" : allowed.ToString();

        private static string RemainingText(int allowed, int used)
        {
            if (allowed <= 0)
                return "unlimited";
            return Math.Max(0, allowed - used).ToString();
        }

        public List<PackageInfoDTO> GetAllPackagesWithInstructor()
        {
            var data = _context.package
            .Include(p => p.Instructor)
            .Include(p => p.Members)
            .Select(p => new PackageInfoDTO
            {
                PackageName = p.pack_title,
                InstructorName = p.Instructor == null
                    ? "N/A"
                    : ((p.Instructor.ins_FName + " " + p.Instructor.ins_LName).Trim() == ""
                        ? p.Instructor.ins_title
                        : (p.Instructor.ins_FName + " " + p.Instructor.ins_LName).Trim()),
                StartDate = p.Members
                    .Where(m => m.startDate.Year >= 2000)
                    .OrderBy(m => m.startDate)
                    .Select(m => (DateTime?)m.startDate)
                    .FirstOrDefault()
            })
            .ToList();

            return data;
        }

        public ClientAttendanceSummaryDTO GetClientAttendanceSummary(int clientId)
        {
            var client = _context.client
                .Include(c => c.Package)
                .Include(c => c.Payments)
                .FirstOrDefault(c => c.client_id == clientId);

            if (client == null)
                return null;

            var monthStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var attendedCount = _context.Attendances
                .Count(a => a.MemberId == clientId
                    && a.AttendanceDate >= monthStart
                    && a.AttendanceDate < monthStart.AddMonths(1));

            var lastSession = _context.Attendances
                .Where(a => a.MemberId == clientId)
                .OrderByDescending(a => a.AttendanceDate)
                .FirstOrDefault();

            return new ClientAttendanceSummaryDTO
            {
                ClientName = client.client_name,
                PackageName = client.Package?.pack_title ?? "No Package",
                JoinDate = client.startDate,
                EndDate = client.endDate,
                TotalSessions = client.Package?.pack_sessionsCount ?? 0,
                AttendedSessions = attendedCount,
                LastAttendanceDate = lastSession?.AttendanceDate,
                CurrentAttendanceTime = DateTime.Now
            };
        }

    }
}
