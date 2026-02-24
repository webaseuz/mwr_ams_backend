using AutoPark.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPark.XUnitTests;

public class CustomWebApiFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");

        // Configure app configuration first
        builder.ConfigureAppConfiguration((context, config) =>
        {
            config.Sources.Clear();
            config.AddJsonFile(
            Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Test.json"),
            optional: false,
            reloadOnChange: true);
            config.AddEnvironmentVariables();
        });

        builder.ConfigureServices((context, services) =>
        {
            #region Remove DbContext
            var DbRemoveWrite = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<WriteEfCoreContext>));
            if (DbRemoveWrite != null)
            {
                services.Remove(DbRemoveWrite);
            }

            var DbRemoveRead = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ReadEfCoreContext>));
            if (DbRemoveRead != null)
            {
                services.Remove(DbRemoveRead);
            }

            var DbRemove = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<DbContext>));
            if (DbRemove != null)
            {
                services.Remove(DbRemove);
            }
            #endregion

            #region AddDbContext For Test
            services.AddScoped<DbContext>();

            var connectionStringNew = context.Configuration.GetSection("Database:PgSql:ConnectionString").Value;

            services.AddDbContext<IWriteEfCoreContext, WriteEfCoreContext>(options =>
            {
                options.UseNpgsql(connectionStringNew);
                options.EnableSensitiveDataLogging();
            });

            services.AddDbContext<IReadEfCoreContext, ReadEfCoreContext>(options =>
            {
                options.UseNpgsql(connectionStringNew);
                options.EnableSensitiveDataLogging();
            });
            #endregion
        });
    }
}
