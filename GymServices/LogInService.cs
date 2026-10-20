using GymData;
using GymData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymServices
{
    public class LogInService
    {
        private readonly GymContextDB _context;

        public LogInService(GymContextDB employees)
        {
            _context = employees;
        }

    
        public Employee? Login(string username, string password)
        {
            return _context.employees
                           .FirstOrDefault(e => e.user_name == username && e.rep_pass == password);
        }
    }
}

