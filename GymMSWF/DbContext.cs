using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymData;

namespace GymMSWF
{
    internal class DbContext
    {
        public static GymContextDB CreateDbContext()
        {
            var configuration = new ConfigurationBuilder()   //Microsoft.Extensions.Configuration.Json
                .SetBasePath(Directory.GetCurrentDirectory()) //Microsoft.Extensions.Configuration
                .AddJsonFile("appsettings.json", optional: false)
                .Build();


            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<GymContextDB>();
            optionsBuilder.UseSqlServer(connectionString);

            return new GymContextDB(optionsBuilder.Options);
        }
    }
}
