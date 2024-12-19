using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static vteCore.Shared.Constants;

namespace vteCore.dbDMR.Models;


public partial class DMRContext
{
    IHostEnvironment _env;
    public DMRContext(DbContextOptions<DMRContext> options, IHostEnvironment env)
        : base(options)
    {
        _env = env;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {


        base.OnConfiguring(optionsBuilder);
        IConfigurationRoot configuration = null;

        if (!_env.IsProduction())
        {
            configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../vteCore/appsettings.json")
                                .Build();
        }
        else
        {
            configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile(@Directory.GetCurrentDirectory() + "/appsettings.json", optional: false, reloadOnChange: true)
                                .AddJsonFile(@Directory.GetCurrentDirectory() + $"/appsettings.{_env.EnvironmentName}.json", optional: true)
                                .Build();
        }

        var builder = new DbContextOptionsBuilder<DMRContext>();
        var connectionString = configuration.GetConnectionString("dbDMR");
        optionsBuilder.UseSqlServer(connectionString);

    }
}