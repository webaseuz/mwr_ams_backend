using Erp.Core.Service.Infrastructure;
using Erp.Service.Adm.Job.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WEBASE.Storage.MinIO;

namespace Erp.Service.Adm.Job.Infrastructure;

public static class DependencyInjection
{
    public static void ConfigureAdmJobInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.ConfigureServiceInfrastructure();
        services.AddScoped<IIdentityProvider, KeycloakIdentityProvider>();
        services.ConfigureSdks();
        //services.AddMinIO(InfrastructureSettings.InfrastructureInstance.WbMinio);
        services.ConfigureRabbitMQ(config);
    }
}
