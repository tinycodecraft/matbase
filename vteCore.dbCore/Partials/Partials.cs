using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vteCore.Shared.Models;
using static vteCore.Shared.Constants;

namespace vteCore.dbCore.Models;


[MetadataType(typeof(CoreUserMeta))]
public partial class CoreUser : IUser, IAuthAuditResult, IAuthResult
{
    [NotMapped]
    public string Email
    {
        get
        {
            if (!string.IsNullOrEmpty(this.email))
                return this.email;
            return $"{this.UserName}@unknown.com";
        }
    }
    [NotMapped]
    public bool IsDivisionAdmin
    {
        get
        {
            return this.AdminScope == nameof(AdminScopeType.Division);
        }
    }

    [NotMapped]
    public bool IsDataAdmin
    {
        get
        {
            return this.AdminScope == nameof(AdminScopeType.Archive);
        }
    }

    [NotMapped]

    public bool IsControlAdmin
    {
        get
        {
            return this.AdminScope == nameof(AdminScopeType.Full);
        }
    }
    [NotMapped]
    public bool NeedReset
    {
        get
        {
            return this.IsReset;
        }
    }


}

public partial class CoreContext
{
    IHostEnvironment _env;
    public CoreContext(DbContextOptions<CoreContext> options, IHostEnvironment env)
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

        var builder = new DbContextOptionsBuilder<CoreContext>();
        var connectionString = configuration.GetConnectionString("dbCore");
        optionsBuilder.UseSqlServer(connectionString);

    }
}