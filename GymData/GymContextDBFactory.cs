using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymData
{
    internal class GymContextDBFactory : IDesignTimeDbContextFactory<GymContextDB>
    {
        public GymContextDB CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\GymMSWF");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<GymContextDB>();
            optionsBuilder.UseSqlServer(connectionString);

            return new GymContextDB(optionsBuilder.Options);
        }
    }
}
