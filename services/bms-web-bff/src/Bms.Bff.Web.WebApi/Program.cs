using System.Reflection;
using Bms.Bff.Web.Infrastructure;
using Bms.Bff.Web.WebApi;
using Bms.Bff.Web.WebApi.Extensions;
using Bms.Common.Infrastructure.Security.Configs;
using Bms.Core.Application;
using Bms.Core.Infrastructure;
using Bms.WEBASE.Constants;
using Bms.WEBASE.DependencyInjection;
using Bms.WEBASE.Helpers;
using Bms.WEBASE.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json.Converters;
using WEBASE.Jaeger;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AlterEnvironmentConfiguration();
AppSettings.Init(builder.Configuration.Get<AppSettings>());

// Configure base services
builder.Services.ConfigureConfigs();
builder.Services.ConfigureCors(AppSettings.Instance.Cors);

// Add infrastructure (includes YOUR superior authentication services)
builder.Services.AddInfrastructure();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddBffInfrastructure(); // BFF-specific infrastructure
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFluentValidationAutoValidation();

// Add localization support
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Add health checks
builder.Services.AddBmsHealthChecks(AppSettings.Instance);

// Add service clients with Refit
builder.Services.AddServiceClients(AppSettings.Instance);

// Add flexible authentication wrapper (preserves YOUR superior implementation)
builder.Services.AddFlexibleAuthentication(AppSettings.Instance);

builder.Services.AddLogSdk(AppSettings.Instance.LogSdk);

builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerServices(AppSettings.Instance.Swagger);

builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.ListenAnyIP(AppSettings.Instance.KestrelCustom.Endpoints.Http1.Port, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
    });
});

builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new StringEnumConverter { AllowIntegerValues = false });
    options.SerializerSettings.Converters.Add(new TrimmingStringConverter());
    options.SerializerSettings.Converters.Add(new WbDateTimeConverter());
    options.SerializerSettings.Converters.Add(new WbDateConverter());
    options.SerializerSettings.DateFormatString = WbConstants.DATE_FORMAT;
});

if (AppSettings.Instance.Jaeger != null)
    builder.AddJaeger(AppSettings.Instance.Jaeger);

var app = builder.Build();

BaseServiceProvider.Initialize(() => app.Services.GetService<IHttpContextAccessor>().HttpContext.RequestServices);

app.UseConfiguredSwagger(AppSettings.Instance.Swagger);

if (AppSettings.Instance.Jaeger != null)
    app.UseMiddleware<ControllerTracingMiddleware>();

app.UseLogSdk();

app.UseConfiguredCors(AppSettings.Instance.Cors);

// Use YOUR superior authentication middleware
app.UseUserDeviceMiddleware();
app.UseJwtTokenMiddleware();

// Add service propagation middleware for BFF
app.UseMiddleware<ServiceHeaderPropagationMiddleware>();

app.UseAuthorization();
app.UseAuthentication();

// Use request localization
var supportedCultures = new[] { "uz-latn", "uz-cyrl", "ru", "en" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.MapControllers();

// Map health check endpoints
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var response = new
        {
            status = report.Status.ToString(),
            checks = report.Entries.Select(x => new
            {
                name = x.Key,
                status = x.Value.Status.ToString(),
                description = x.Value.Description,
                duration = x.Value.Duration.TotalMilliseconds
            }),
            totalDuration = report.TotalDuration.TotalMilliseconds
        };
        await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
    }
});

// Map health check UI if not in production
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
if (environment != "Production")
{
    app.MapHealthChecksUI(options => options.UIPath = "/health-ui");
}

app.Run();

public partial class Program { }