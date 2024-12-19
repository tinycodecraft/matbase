using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace vteCore.dbCore.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CoreContext>
    {
        IHostEnvironment _env;

        public DesignTimeDbContextFactory()
        {

        }

        public DesignTimeDbContextFactory(IHostEnvironment env)
        {
            _env = env;

        }
        public CoreContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../vteCore/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<CoreContext>();
            var connectionString = configuration.GetConnectionString("dbCore");
            builder.UseSqlServer(connectionString, opt => opt.MigrationsAssembly("vteCore.dbCore"));
            return new CoreContext(builder.Options, _env);

        }
    }
}
