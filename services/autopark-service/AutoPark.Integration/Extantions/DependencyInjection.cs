using AutoPark.Integration;
using AutoPark.Integration.Service;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPark.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddIntagration(this IServiceCollection services, AutoParkHttpConfig httpConfig)
    {
        services.AddSingleton(httpConfig);
        services.AddScoped<YhxbbHttpClient>();
        services.AddScoped<AutoParkHttpClient>();
        services.AddScoped<ICashManagementService, CashManagementService>();
        services.AddScoped<IYhxbbIntegrationService, YhxbbIntegrationService>();
        return services;
    }
}
