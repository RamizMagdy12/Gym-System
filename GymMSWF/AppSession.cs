using GymData.Models;

namespace GymMSWF
{
    public static class AppSession
    {
        private static readonly Dictionary<string, (bool View, bool Edit)> Permissions =
            new(StringComparer.OrdinalIgnoreCase);

        public static string Role { get; private set; } = string.Empty;
        public static int EmployeeId { get; private set; }

        public static bool IsAdmin =>
            string.Equals(Role, "Admin", StringComparison.OrdinalIgnoreCase);

        public static void Set(Employee employee, IEnumerable<RolePermission> permissions)
        {
            Role = employee.role ?? string.Empty;
            EmployeeId = employee.rep_id;
            Permissions.Clear();
            foreach (var permission in permissions)
                Permissions[permission.Screen] = (permission.CanView, permission.CanEdit);
        }

        public static bool CanView(string screen)
        {
            if (IsAdmin)
                return true;
            return Permissions.TryGetValue(screen, out var access) && access.View;
        }

        public static bool CanEdit(string screen)
        {
            if (IsAdmin)
                return true;
            return Permissions.TryGetValue(screen, out var access) && access.Edit;
        }

        public static void HideMutations(Control root, string screen)
        {
            if (CanEdit(screen))
                return;

            foreach (Control control in root.Controls)
            {
                if (control is ButtonBase button && IsMutation(button.Text))
                    button.Visible = false;
                HideMutations(control, screen);
            }
        }

        private static bool IsMutation(string? text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            return text.Contains("Add", StringComparison.OrdinalIgnoreCase)
                || text.Contains("Update", StringComparison.OrdinalIgnoreCase)
                || text.Contains("Delete", StringComparison.OrdinalIgnoreCase)
                || text.Contains("Edit", StringComparison.OrdinalIgnoreCase)
                || text.Contains("Save", StringComparison.OrdinalIgnoreCase)
                || text.Contains("Collect", StringComparison.OrdinalIgnoreCase)
                || text.Contains("Check in", StringComparison.OrdinalIgnoreCase);
        }
    }
}
