using Erp.Core.Service.Application;
using Erp.Core.Service.Infrastructure.Localization;
using Microsoft.Extensions.DependencyInjection;
using WEBASE.i18n;

namespace Erp.Core.Service.Infrastructure;

public static class DependencyInjection
{
    public static void ConfigureServiceInfrastructure(this IServiceCollection services)
    {
        // Culture
        services.AddScoped<ICultureHelper, CultureHelper>();

        // Time
        services.AddSingleton(TimeProvider.System);

        // Database
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        // User
        services.AddHttpContextAccessor();

        // configure config
        services.AddSingleton(ServiceAppSettings.ServiceInstance.Culture);
        services.AddSingleton(ServiceAppSettings.ServiceInstance.Database);

        // SequenceNextId
        services.AddScoped<ISequenceNextIdService, SequenceNextIdService>();

        // Localization
        services.AddLocalizationService();
    }
}
