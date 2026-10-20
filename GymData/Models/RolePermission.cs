using System.ComponentModel.DataAnnotations;

namespace GymData.Models
{
    public class RolePermission
    {
        [Key]
        public int PermissionId { get; set; }

        public int RoleId { get; set; }

        public string Screen { get; set; } = string.Empty;

        public bool CanView { get; set; }

        public bool CanEdit { get; set; }

        public AppRole? Role { get; set; }
    }
}
