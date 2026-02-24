using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WEBASE.LogSdk;
using WEBASE.LogSdk.BLL.Managers;
using WEBASE.LogSdk.BLL.Services;
using WEBASE.LogSdk.Controllers;
using WEBASE.LogSdk.Core.Enums;
using WEBASE.LogSdk.DAL;
using WEBASE.LogSdk.DAL.Analyzers;
using WEBASE.LogSdk.DAL.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddLogSdk(this IServiceCollection services, ILogSdkConfiguration configuration)
    {
        services.AddLogSdk(options =>
        {
            options.ApplicationName = configuration.ApplicationName;
            options.DatabaseType = configuration.DatabaseType;
            options.ConnectionString = configuration.ConnectionString;
            options.AppError = configuration.AppError;
            options.AppErrorArchive = configuration.AppErrorArchive;
            options.ShowControllers = configuration.ShowControllers;
        });
    }

    public static void AddLogSdk(this IServiceCollection services, Action<ILogSdkConfiguration> setupAction)
    {
        // register config
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        if (setupAction == null)
            throw new ArgumentNullException(nameof(setupAction));

        var configurationInstance = Activator.CreateInstance<LogSdkConfiguration>();
        setupAction(configurationInstance);
        services.AddSingleton(typeof(ILogSdkConfiguration), configurationInstance);

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // register db context
        services.ConfigureDbContext(configurationInstance);

        // register controllers
        if (configurationInstance.ShowControllers)
        {
            services.AddMvc()
                .AddApplicationPart(typeof(AppErrorController).Assembly); // Register only if true
        }
        else
        {
            services.AddMvc(options =>
            {
                // No need to configure for library controllers
            }).ConfigureApplicationPartManager(manager =>
            {
                // Remove library's controllers
                var partToRemove = manager.ApplicationParts.FirstOrDefault(part =>
                    part.Name == typeof(AppErrorController).Assembly.GetName().Name);

                if (partToRemove != null)
                {
                    manager.ApplicationParts.Remove(partToRemove);
                }
            });
        }

        // register app services
        services.ConfigureAppServices();
    }

    internal static void ConfigureAppServices(this IServiceCollection services)
    {
        services.AddScoped<AppErrorService>();
        services.AddScoped<AppErrorArchiveService>();
        services.AddScoped<ErrorScopeService>();
        services.AddScoped<ErrorScopeArchiveService>();
        services.AddScoped<IErrorManager, ErrorManager>();
        services.AddScoped(typeof(Repository<,>));
    }

    internal static IServiceCollection ConfigureDbContext(this IServiceCollection services, ILogSdkConfiguration configuration)
    {
        // Create a dictionary to map DatabaseType to migrations assembly
        var databaseContextMap = new Dictionary<DatabaseType, string>
        {
            { DatabaseType.MSSQL, "SqlServerMigrations" },
            { DatabaseType.POSTGRES, "PgSqlMigrations" },
            { DatabaseType.ORACLE, "OracleMigrations" }
        };

        // Check if the specified DatabaseType is supported
        if (!databaseContextMap.TryGetValue(configuration.DatabaseType, out var migrationAssembly))
        {
            throw new Exception($"Unsupported database type: {configuration.DatabaseType}");
        }

        switch (configuration.DatabaseType)
        {
            case DatabaseType.POSTGRES:
                services.AddDbContext<PgSqlContext>(options =>
                {
                    options.UseNpgsql(configuration.ConnectionString, b => b.MigrationsAssembly(migrationAssembly));
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                });
                services.AddScoped<LogSdkContext>(x => x.GetService<PgSqlContext>()!);
                services.AddScoped<IExceptionAnalyzer, PgSqlExceptionAnalyzer>();
                break;
            default:
                throw new Exception($"Unsupported database type: {configuration.DatabaseType}");
        }

        return services;
    }
}
