using ServiceDesk.Application;
using Bms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using WEBASE.LogSdk.DAL;

namespace Microsoft.Extensions.DependencyInjection;

public static class DbServiceExtensions
{
    public static void ConfigureDbServices(this IServiceCollection services,DatabaseConfig config)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddScoped<DbContext>(x => x.GetService<PgSqlContext>()!);

        //Write context
        services.AddDbContext<IWriteEfCoreContext, WriteEfCoreContext>(options =>
        {
            options.UseNpgsql(config.PgSql.ConnectionString);
            options.EnableSensitiveDataLogging();
        });

        //Read context
        services.AddDbContext<IReadEfCoreContext, ReadEfCoreContext>(options =>
        {
            options.UseNpgsql(config.PgSql.ConnectionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
    }
}
