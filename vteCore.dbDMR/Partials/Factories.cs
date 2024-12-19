using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace vteCore.dbDMR.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DMRContext>
    {
        IHostEnvironment _env;

        public DesignTimeDbContextFactory()
        {

        }

        public DesignTimeDbContextFactory(IHostEnvironment env)
        {
            _env = env;

        }
        public DMRContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../vteCore/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<DMRContext>();
            var connectionString = configuration.GetConnectionString("dbDMR");
            builder.UseSqlServer(connectionString, opt => opt.MigrationsAssembly("vteCore.dbDMR"));
            return new DMRContext(builder.Options, _env);

        }
    }
}
