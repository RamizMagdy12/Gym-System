using GymData;
using GymData.Models;
using Microsoft.EntityFrameworkCore;

namespace GymServices
{
    public class RoleService
    {
        private readonly GymContextDB _context;

        public RoleService(GymContextDB context)
        {
            _context = context;
        }

        public void EnsureSeeded()
        {
            if (!_context.AppRoles.Any())
            {
                AddRole("Admin", FullAccess());
                AddRole("Reception", new Dictionary<string, (bool View, bool Edit)>
                {
                    [AccessScreens.Dashboard] = (true, false),
                    [AccessScreens.Packages] = (true, false),
                    [AccessScreens.Clients] = (true, true),
                    [AccessScreens.Attendance] = (true, true),
                    [AccessScreens.Payments] = (true, true),
                    [AccessScreens.Equipment] = (true, false)
                });
                AddRole("Coach", new Dictionary<string, (bool View, bool Edit)>
                {
                    [AccessScreens.Packages] = (true, false),
                    [AccessScreens.Clients] = (true, false),
                    [AccessScreens.Attendance] = (true, true)
                });
                AddRole("User", new Dictionary<string, (bool View, bool Edit)>
                {
                    [AccessScreens.Packages] = (true, false),
                    [AccessScreens.Clients] = (true, true),
                    [AccessScreens.Attendance] = (true, true),
                    [AccessScreens.Payments] = (true, false),
                    [AccessScreens.Equipment] = (true, false)
                });
                _context.SaveChanges();
            }
        }

        public List<AppRole> GetRoles()
        {
            return _context.AppRoles
                .Include(r => r.Permissions)
                .OrderBy(r => r.Name)
                .ToList();
        }

        public List<string> GetRoleNames()
        {
            EnsureSeeded();
            return _context.AppRoles.OrderBy(r => r.Name).Select(r => r.Name).ToList();
        }

        public List<RolePermission> GetPermissions(string roleName)
        {
            EnsureSeeded();
            var role = _context.AppRoles
                .Include(r => r.Permissions)
                .FirstOrDefault(r => r.Name == roleName);

            if (role == null)
                return new List<RolePermission>();

            return role.Permissions.ToList();
        }

        public AppRole AddRole(string name)
        {
            var trimmed = name.Trim();
            if (string.IsNullOrWhiteSpace(trimmed))
                throw new InvalidOperationException("Enter a role name.");

            if (_context.AppRoles.Any(r => r.Name == trimmed))
                throw new InvalidOperationException("This role already exists.");

            var role = new AppRole { Name = trimmed };
            _context.AppRoles.Add(role);
            _context.SaveChanges();
            return role;
        }

        public void SavePermissions(int roleId, IEnumerable<(string Screen, bool CanView, bool CanEdit)> rows)
        {
            var role = _context.AppRoles.Include(r => r.Permissions).FirstOrDefault(r => r.RoleId == roleId);
            if (role == null)
                throw new InvalidOperationException("Role not found.");

            if (string.Equals(role.Name, "Admin", StringComparison.OrdinalIgnoreCase))
                return;

            foreach (var row in rows)
            {
                bool canEdit = row.CanEdit && row.CanView;
                bool canView = row.CanView || canEdit;
                var existing = role.Permissions.FirstOrDefault(p => p.Screen == row.Screen);
                if (existing == null)
                {
                    role.Permissions.Add(new RolePermission
                    {
                        Screen = row.Screen,
                        CanView = canView,
                        CanEdit = canEdit
                    });
                }
                else
                {
                    existing.CanView = canView;
                    existing.CanEdit = canEdit;
                }
            }

            _context.SaveChanges();
        }

        private void AddRole(string name, IEnumerable<RolePermission> permissions)
        {
            _context.AppRoles.Add(new AppRole
            {
                Name = name,
                Permissions = permissions.ToList()
            });
        }

        private void AddRole(string name, Dictionary<string, (bool View, bool Edit)> access)
        {
            AddRole(name, access.Select(pair => new RolePermission
            {
                Screen = pair.Key,
                CanView = pair.Value.View,
                CanEdit = pair.Value.Edit
            }));
        }

        private static IEnumerable<RolePermission> FullAccess()
        {
            return AccessScreens.All.Select(screen => new RolePermission
            {
                Screen = screen,
                CanView = true,
                CanEdit = true
            });
        }
    }
}
