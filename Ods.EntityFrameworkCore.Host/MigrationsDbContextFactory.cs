using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ods.Common.Services;
using Ods.Repository.Data;
using Microsoft.Extensions.Configuration;

namespace Ods.EntityFrameworkCore.Host
{
    public class MigrationsDbContextFactory : IDesignTimeDbContextFactory<MigrationDbContext>
    {
        public MigrationDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            var builder = new DbContextOptionsBuilder<OdsDbContext>()
                .UseSqlServer(configuration["ConnectionStrings:SqlServer"]);

            return new MigrationDbContext(builder.Options,null);
        }
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
