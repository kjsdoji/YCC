using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace YCC.Data.EF
{
    class YCCDbContextFactory : IDesignTimeDbContextFactory<YCCDbContext>
    {
        public YCCDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("YCCDb");

            var optionsBuilder = new DbContextOptionsBuilder<YCCDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new YCCDbContext(optionsBuilder.Options);
        }
    }
}
