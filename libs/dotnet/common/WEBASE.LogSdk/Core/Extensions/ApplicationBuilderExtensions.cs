using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WEBASE.LogSdk;
using WEBASE.LogSdk.BLL.Managers;
using WEBASE.LogSdk.Core.Enums;
using WEBASE.LogSdk.Core.Extensions;
using WEBASE.LogSdk.DAL;
using WEBASE.Security.Abstraction;

namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationBuilderExtensions
{
    public static void UseLogSdk(this IApplicationBuilder app)
    {
        var configuration = app.ApplicationServices.GetService<ILogSdkConfiguration>();
        var logger = app.ApplicationServices.GetService<ILogger>();

        #region apply db migration
        var builder = new DbContextOptionsBuilder<PgSqlContext>();

        switch (configuration!.DatabaseType)
        {
            case DatabaseType.POSTGRES:
                builder.UseNpgsql(configuration.ConnectionString);
                break;
        }

        using (var dbContext = new PgSqlContext(builder.Options))
        {
            try
            {
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while migrating WEBASE.LogSdk database - " + ex);
            }
        }
        #endregion

        // NOTE: If there is no need for custom middleware, it is recommended to use the built-in exception handler
        // register custom exception middleware 
        //app.UseMiddleware<ExceptionMiddleware>(configuration!.AppError);

        // register built-in exception handler (recomended)
        app.ConfigureExceptionHandler(configuration.AppError);
    }

    internal static void ConfigureExceptionHandler(this IApplicationBuilder app, AppErrorOptions appErrorOptions)
    {
        var logger = app.ApplicationServices.GetService<ILogger>();

        if (appErrorOptions.IncludeBody)
        {
            app.Use(async (context, next) =>
            {
                context.Request.EnableBuffering();
                await next();
            });
        }

        app.UseExceptionHandler(config =>
        {
            try
            {
                config.Run(async context =>
                {
                    try
                    {
                        var authService = context.RequestServices.GetRequiredService<IBaseAuthService>();
                        var appErrorService = context.RequestServices.GetRequiredService<IErrorManager>();
                        var configuration = app.ApplicationServices.GetService<ILogSdkConfiguration>();

                        await context.HandleExceptionAsync(appErrorService, authService, configuration!.AppError, logger);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Exception during handling error in LogSdk.");
                    }
                });
            }
            catch (Exception ex)
            {
                logger?.LogCritical(ex, "An error occurred while handling exception in LogSdk:EXEPTION_HANDLER.");
            }
        });
    }
}
