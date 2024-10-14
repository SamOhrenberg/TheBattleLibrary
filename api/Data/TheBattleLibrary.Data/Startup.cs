using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace TheBattleLibrary.Data;

/// <summary>
/// Sets up the configured Database Providers
/// </summary>
public class Startup
{
    public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var databaseType = configuration.GetValue<string>("DatabaseType");
        var connectionString = configuration.GetConnectionString(databaseType);

        switch (databaseType.ToLower())
        {
            case "sqlserver":
                //services.AddDbContext<IApplicationDbContext, SqlServerDbContext>((serviceProvider, options) =>
                //{
                //    options.UseSqlServer(connectionString);
                //});
                break;
            case "postgresql":
                //services.AddDbContext<IApplicationDbContext, PostgreSqlDbContext>((serviceProvider, options) =>
                //{
                //    options.UseNpgsql(connectionString);
                //});
                break;
            case "mysql":
                //services.AddDbContext<IApplicationDbContext, MySqlDbContext>((serviceProvider, options) =>
                //{
                //    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                //});
                break;
            case "sqlite":
                services.AddDbContext<IApplicationDbContext, SqliteDbContext>((serviceProvider, options) =>
                {
                    options.UseSqlite(connectionString);
                });
                break;
            default:
                throw new Exception("Unsupported database type");
        }

        return services;
    }
}
