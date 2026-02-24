using Bms.WEBASE.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Bms.Core.Infrastructure;

public static class CorsExtensions
{
    public static void UseConfiguredCors(
        this IApplicationBuilder app,
        CorsConfig config)
    {
        if (config.UseCors)
            app.UseCors("AllowedOrgins");
        else
            app.UseCors("AllowAll");
    }

    public static void ConfigureCors(
        this IServiceCollection services,
        CorsConfig config)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            options.AddPolicy("AllowedOrgins",
                builder =>
                {
                    if (config.UseCors)
                        builder
                        .WithOrigins(config.AllowedOrgins.Split(new string[] { ",", ";" }, StringSplitOptions.None))
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    else
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            // for signalR Cors
            options.AddPolicy("SignalRCors", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(_ => true)
                    .AllowCredentials();
            });

        });
    }
}
