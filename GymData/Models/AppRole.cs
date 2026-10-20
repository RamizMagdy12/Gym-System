using System.ComponentModel.DataAnnotations;

namespace GymData.Models
{
    public class AppRole
    {
        [Key]
        public int RoleId { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<RolePermission> Permissions { get; set; } = new List<RolePermission>();
    }
}
