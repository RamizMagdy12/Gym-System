using GymServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMSWF
{
    public partial class LogInForm : Form
    {
        private readonly LogInService _loginService;

        public LogInForm()
        {
            InitializeComponent();
            AcceptButton = loginBtn;
            passTextBox.UseSystemPasswordChar = true;
            var context = DbContext.CreateDbContext();
            _loginService = new LogInService(context);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = userNameText.Text.Trim();
            string password = passTextBox.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            try
            {
                var employee = _loginService.Login(username, password);
                if (employee == null)
                {
                    MessageBox.Show("Username or password is incorrect.");
                    passTextBox.Clear();
                    passTextBox.Focus();
                    return;
                }

                var roles = new RoleService(DbContext.CreateDbContext());
                roles.EnsureSeeded();
                AppSession.Set(employee, roles.GetPermissions(employee.role));
                Hide();
                using (var dashboard = new Dashboard(employee.role))
                {
                    dashboard.ShowDialog(this);
                }

                Show();
                passTextBox.Clear();
                passTextBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not sign in: " + ex.Message);
                Show();
            }
        }
    }
}
