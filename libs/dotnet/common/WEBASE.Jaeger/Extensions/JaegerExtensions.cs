using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace WEBASE.Jaeger;
public static class JaegerExtensions
{
    public static void AddJaeger(this WebApplicationBuilder builder, JaegerConfig config)
    {
        if (config is not null)
        {
            builder.Services.AddOpenTelemetry()
                .WithTracing(builder => builder
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(config.AppName))
                .AddSource(JaegerTraceConst.ANALYZER)
                .AddAspNetCoreInstrumentation()
                .AddEntityFrameworkCoreInstrumentation("database", opt =>
                {
                    opt.SetDbStatementForText = true;
                    opt.SetDbStatementForStoredProcedure = true;
                })
                .AddHttpClientInstrumentation()
                .AddJaegerExporter(options =>
                {
                    options.AgentHost = config.Host;
                    options.AgentPort = int.Parse(config.Port);
                }));
        }
        else
        {
            builder.Services.AddOpenTelemetry()
                .WithTracing(builder => builder
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("app-service"))
                .AddSource(JaegerTraceConst.ANALYZER)
                .AddAspNetCoreInstrumentation()
                .AddEntityFrameworkCoreInstrumentation("database", opt =>
                {
                    opt.SetDbStatementForText = true;
                    opt.SetDbStatementForStoredProcedure = true;
                })
                .AddHttpClientInstrumentation()
                );
        }
    }
}