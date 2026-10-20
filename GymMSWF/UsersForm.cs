using GymData.Models;
using GymServices;

namespace GymMSWF
{
    public class UsersForm : Form
    {
        private readonly EmployeeServices _employees;
        private readonly RoleService _roles;
        private readonly DataGridView _users = new();
        private readonly ListBox _roleList = new();
        private readonly DataGridView _access = new();
        private readonly Label _roleHint = new();
        private List<Employee> _people = new();
        private bool _loadingAccess;

        public UsersForm()
        {
            var context = DbContext.CreateDbContext();
            _employees = new EmployeeServices(context);
            _roles = new RoleService(context);
            _roles.EnsureSeeded();

            Text = "Users";
            BackColor = Color.FromArgb(36, 48, 56);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 10F);
            AutoScaleMode = AutoScaleMode.None;
            Build();
            Load += async (_, _) => await Reload();
        }

        private void Build()
        {
            var header = new Label
            {
                Text = "Users and roles",
                Dock = DockStyle.Top,
                Height = 48,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Padding = new Padding(16, 12, 0, 0),
                BackColor = Color.FromArgb(47, 61, 71)
            };

            var usersPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12) };
            var usersBar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 48,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Color.FromArgb(36, 48, 56)
            };
            usersBar.Controls.Add(MakeButton("Add user", Color.FromArgb(74, 169, 81), async (_, _) => await AddUser()));
            usersBar.Controls.Add(MakeButton("Update role", Color.FromArgb(61, 155, 150), async (_, _) => await ChangeRole()));
            usersBar.Controls.Add(MakeButton("Delete", Color.FromArgb(180, 60, 60), async (_, _) => await DeleteUser()));

            StyleGrid(_users);
            _users.Dock = DockStyle.Fill;
            usersPanel.Controls.Add(_users);
            usersPanel.Controls.Add(usersBar);

            var rolesPanel = new Panel
            {
                Dock = DockStyle.Right,
                Width = 460,
                Padding = new Padding(12),
                BackColor = Color.FromArgb(47, 61, 71)
            };
            var rolesBar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 48,
                WrapContents = false,
                BackColor = Color.FromArgb(47, 61, 71)
            };
            rolesBar.Controls.Add(MakeButton("Add role", Color.FromArgb(74, 169, 81), async (_, _) => await AddRole()));
            rolesBar.Controls.Add(MakeButton("Save access", Color.FromArgb(61, 155, 150), async (_, _) => await SaveAccess()));

            _roleList.Dock = DockStyle.Top;
            _roleList.Height = 120;
            _roleList.BackColor = Color.FromArgb(36, 48, 56);
            _roleList.ForeColor = Color.White;
            _roleList.BorderStyle = BorderStyle.None;
            _roleList.SelectedIndexChanged += (_, _) => ShowAccess();

            _roleHint.Dock = DockStyle.Top;
            _roleHint.Height = 42;
            _roleHint.ForeColor = Color.FromArgb(180, 190, 205);
            _roleHint.Text = "Can see = opens the page. Can edit = add, update, and delete.";

            StyleGrid(_access);
            _access.Dock = DockStyle.Fill;
            _access.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _access.Columns.Add(new DataGridViewTextBoxColumn { Name = "Screen", HeaderText = "Page", ReadOnly = true });
            _access.Columns.Add(new DataGridViewCheckBoxColumn { Name = "View", HeaderText = "Can see" });
            _access.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Edit", HeaderText = "Can edit" });
            _access.CellContentClick += Access_CellContentClick;

            rolesPanel.Controls.Add(_access);
            rolesPanel.Controls.Add(_roleHint);
            rolesPanel.Controls.Add(_roleList);
            rolesPanel.Controls.Add(rolesBar);

            Controls.Add(usersPanel);
            Controls.Add(rolesPanel);
            Controls.Add(header);
        }

        private static Button MakeButton(string text, Color color, EventHandler onClick)
        {
            var button = new Button
            {
                Text = text,
                AutoSize = true,
                Height = 34,
                Margin = new Padding(0, 6, 8, 0),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += onClick;
            return button;
        }

        private static void StyleGrid(DataGridView grid)
        {
            grid.ReadOnly = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.BackgroundColor = Color.FromArgb(36, 48, 56);
            grid.BorderStyle = BorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeight = 34;
            grid.RowTemplate.Height = 32;
            grid.GridColor = Color.FromArgb(47, 61, 71);
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(61, 155, 150);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.DefaultCellStyle.BackColor = Color.FromArgb(36, 48, 56);
            grid.DefaultCellStyle.ForeColor = Color.White;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(74, 169, 81);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private async Task Reload()
        {
            _people = await _employees.GetAll();
            _users.DataSource = _people.Select(person => new
            {
                person.rep_id,
                Name = person.rep_name,
                Username = person.user_name,
                Role = person.role,
                Phone = person.rep_phone
            }).ToList();
            if (_users.Columns.Contains("rep_id"))
                _users.Columns["rep_id"].Visible = false;
            foreach (DataGridViewColumn column in _users.Columns)
                column.ReadOnly = true;

            var selected = SelectedRole()?.RoleId;
            _roleList.DataSource = null;
            _roleList.DataSource = _roles.GetRoles();
            _roleList.DisplayMember = nameof(AppRole.Name);
            if (selected != null)
            {
                for (int i = 0; i < _roleList.Items.Count; i++)
                {
                    if (_roleList.Items[i] is AppRole role && role.RoleId == selected)
                        _roleList.SelectedIndex = i;
                }
            }
            ShowAccess();
        }

        private AppRole? SelectedRole() => _roleList.SelectedItem as AppRole;

        private void ShowAccess()
        {
            var role = SelectedRole();
            _access.Rows.Clear();
            if (role == null)
                return;

            bool locked = string.Equals(role.Name, "Admin", StringComparison.OrdinalIgnoreCase);
            _roleHint.Text = locked
                ? "Admin can see and edit every page."
                : "Can see opens the page. Can edit allows add, update, and delete.";
            _access.ReadOnly = locked;

            foreach (var screen in AccessScreens.All)
            {
                var permission = role.Permissions.FirstOrDefault(p => p.Screen == screen);
                bool view = locked || (permission?.CanView ?? false);
                bool edit = locked || (permission?.CanEdit ?? false);
                int row = _access.Rows.Add(screen, view, edit);
                _access.Rows[row].ReadOnly = locked;
            }
        }

        private void Access_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (_loadingAccess || e.RowIndex < 0 || _access.ReadOnly)
                return;

            _access.CommitEdit(DataGridViewDataErrorContexts.Commit);
            bool view = Convert.ToBoolean(_access.Rows[e.RowIndex].Cells["View"].Value ?? false);
            bool edit = Convert.ToBoolean(_access.Rows[e.RowIndex].Cells["Edit"].Value ?? false);
            _loadingAccess = true;
            if (e.ColumnIndex == _access.Columns["Edit"].Index && edit)
                _access.Rows[e.RowIndex].Cells["View"].Value = true;
            if (e.ColumnIndex == _access.Columns["View"].Index && !view)
                _access.Rows[e.RowIndex].Cells["Edit"].Value = false;
            _loadingAccess = false;
        }

        private async Task SaveAccess()
        {
            var role = SelectedRole();
            if (role == null)
                return;

            if (string.Equals(role.Name, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Admin always has full access.");
                return;
            }

            var rows = _access.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells["Screen"].Value != null)
                .Select(row => (
                    Screen: row.Cells["Screen"].Value!.ToString()!,
                    CanView: Convert.ToBoolean(row.Cells["View"].Value ?? false),
                    CanEdit: Convert.ToBoolean(row.Cells["Edit"].Value ?? false)));

            try
            {
                _roles.SavePermissions(role.RoleId, rows);
                if (string.Equals(role.Name, AppSession.Role, StringComparison.OrdinalIgnoreCase))
                    MessageBox.Show("Access saved. Sign out and sign in again to apply it to your menu.");
                else
                    MessageBox.Show("Access saved. Users with this role will see it the next time they sign in.");
                await Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task AddRole()
        {
            var name = Prompt("New role", "Role name");
            if (string.IsNullOrWhiteSpace(name))
                return;

            try
            {
                _roles.AddRole(name);
                await Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task AddUser()
        {
            using var dialog = new UserEditorForm(_roles.GetRoleNames());
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            if (await _employees.IsUsernameTaken(dialog.Username))
            {
                MessageBox.Show("This username is already used.");
                return;
            }

            await _employees.Add(new Employee
            {
                rep_name = dialog.PersonName,
                user_name = dialog.Username,
                rep_pass = dialog.Password,
                role = dialog.RoleName,
                rep_phone = string.IsNullOrWhiteSpace(dialog.Phone) ? "00000000" : dialog.Phone,
                rep_gender = "Male",
                rep_address = "-",
                rep_birthDate = DateTime.Today
            });
            await Reload();
        }

        private async Task ChangeRole()
        {
            if (_users.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user.");
                return;
            }

            int id = Convert.ToInt32(_users.SelectedRows[0].Cells["rep_id"].Value);
            var person = _people.FirstOrDefault(p => p.rep_id == id);
            if (person == null)
                return;

            var role = Prompt("Change role", "Role for " + person.rep_name, _roles.GetRoleNames(), person.role);
            if (string.IsNullOrWhiteSpace(role))
                return;

            person.role = role;
            await _employees.Update(person);
            await Reload();
        }

        private async Task DeleteUser()
        {
            if (_users.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user.");
                return;
            }

            int id = Convert.ToInt32(_users.SelectedRows[0].Cells["rep_id"].Value);
            if (id == AppSession.EmployeeId)
            {
                MessageBox.Show("You cannot delete the signed-in user.");
                return;
            }

            if (MessageBox.Show("Delete this user?", "Users", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                await _employees.Delete(id);
                await Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static string? Prompt(string title, string label, IEnumerable<string>? choices = null, string? current = null)
        {
            using var dialog = new Form
            {
                Text = title,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                ClientSize = new Size(360, 150),
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(47, 61, 71),
                ForeColor = Color.White
            };
            dialog.Controls.Add(new Label { Text = label, Location = new Point(16, 16), AutoSize = true });
            Control input;
            if (choices == null)
            {
                var box = new TextBox { Location = new Point(16, 44), Width = 320 };
                input = box;
            }
            else
            {
                var combo = new ComboBox
                {
                    Location = new Point(16, 44),
                    Width = 320,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                combo.Items.AddRange(choices.Cast<object>().ToArray());
                if (!string.IsNullOrWhiteSpace(current))
                    combo.SelectedItem = current;
                if (combo.SelectedIndex < 0 && combo.Items.Count > 0)
                    combo.SelectedIndex = 0;
                input = combo;
            }
            dialog.Controls.Add(input);
            var ok = new Button
            {
                Text = "Save",
                DialogResult = DialogResult.OK,
                Location = new Point(250, 90),
                BackColor = Color.FromArgb(74, 169, 81),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            dialog.Controls.Add(ok);
            dialog.AcceptButton = ok;
            if (dialog.ShowDialog() != DialogResult.OK)
                return null;
            return input is ComboBox comboBox ? comboBox.SelectedItem?.ToString() : input.Text.Trim();
        }
    }

    public class UserEditorForm : Form
    {
        private readonly TextBox _name = new();
        private readonly TextBox _username = new();
        private readonly TextBox _password = new();
        private readonly TextBox _phone = new();
        private readonly ComboBox _role = new();

        public string PersonName => _name.Text.Trim();
        public string Username => _username.Text.Trim();
        public string Password => _password.Text;
        public string Phone => _phone.Text.Trim();
        public string RoleName => _role.SelectedItem?.ToString() ?? string.Empty;

        public UserEditorForm(IEnumerable<string> roles)
        {
            Text = "Add user";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(420, 320);
            BackColor = Color.FromArgb(47, 61, 71);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 10F);

            AddField("Name", _name, 16);
            AddField("Username", _username, 70);
            _password.UseSystemPasswordChar = true;
            AddField("Password", _password, 124);
            AddField("Phone", _phone, 178);
            Controls.Add(new Label { Text = "Role", Location = new Point(20, 232), AutoSize = true });
            _role.DropDownStyle = ComboBoxStyle.DropDownList;
            _role.Location = new Point(120, 228);
            _role.Width = 270;
            _role.Items.AddRange(roles.Cast<object>().ToArray());
            if (_role.Items.Count > 0)
                _role.SelectedIndex = 0;
            Controls.Add(_role);

            var save = new Button
            {
                Text = "Save",
                Location = new Point(120, 270),
                Size = new Size(270, 36),
                BackColor = Color.FromArgb(74, 169, 81),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            save.FlatAppearance.BorderSize = 0;
            save.Click += (_, _) =>
            {
                if (string.IsNullOrWhiteSpace(PersonName) || string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                {
                    MessageBox.Show("Name, username, and password are required.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(RoleName))
                {
                    MessageBox.Show("Select a role.");
                    return;
                }
                DialogResult = DialogResult.OK;
                Close();
            };
            Controls.Add(save);
            AcceptButton = save;
        }

        private void AddField(string caption, TextBox box, int top)
        {
            Controls.Add(new Label { Text = caption, Location = new Point(20, top + 4), AutoSize = true });
            box.Location = new Point(120, top);
            box.Width = 270;
            Controls.Add(box);
        }
    }
}
