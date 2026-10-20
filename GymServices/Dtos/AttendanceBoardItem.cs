namespace GymServices.Dtos
{
	public class AttendanceBoardItem
	{
		public int ClientId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;
		public string Package { get; set; } = string.Empty;
		public string Status { get; set; } = string.Empty;
		public int AttendedThisMonth { get; set; }
		public int AllowedSessions { get; set; }
		public string Remaining { get; set; } = string.Empty;
		public string LastVisit { get; set; } = string.Empty;
		public bool CheckedInToday { get; set; }
		public bool CanCheckIn { get; set; }
		public string Note { get; set; } = string.Empty;
	}
}
