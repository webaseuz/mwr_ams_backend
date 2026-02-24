using AutoPark.Application;
using AutoPark.Application.Security;
using AutoPark.Application.UseCases.NotificationServices;
using AutoPark.Infrastructure;
using AutoPark.Infrastructure.Security;
using Bms.Core.Infrastructure;
using Bms.WEBASE.DependencyInjection;
using Bms.WEBASE.Helpers;

namespace AutoPark.Jobs;

public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        AppSettings.Init(Configuration.Get<AppSettings>());
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureDbServices(AppSettings.Instance.Database);
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IWriteEfCoreContext, WriteEfCoreContext>();
        services.AddScoped<IAsyncAppAuthService, AppAuthService>();
        services.AddScoped<ICultureHelper, CultureHelper>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton(AppSettings.Instance.QuartzDriverPenaltyNotification);
        services.AddSingleton(AppSettings.Instance.Cors);
        services.AddSingleton(AppSettings.Instance.ReferenceToken);

        //services.AddSwaggerGen();

        services.ConfigureQuartzServices();
        services.ConfigureCors(AppSettings.Instance.Cors);
        services.AddInfrastructure();
        //services.ConfigureSwaggerServices(AppSettings.Instance.Swagger);
    }

    public void Configure(IApplicationBuilder app)
    {
        BaseServiceProvider.Initialize(() => app.ApplicationServices.GetService<IHttpContextAccessor>().HttpContext.RequestServices);
        //app.UseConfiguredSwagger(AppSettings.Instance.Swagger);
        app.UseConfiguredCors(AppSettings.Instance.Cors);
        app.UseCors();
    }
}
