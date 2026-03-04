using Erp.Core.Service.Infrastructure;
using Erp.Service.Adm.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WEBASE.Storage.MinIO;

namespace Erp.Service.Adm.Infrastructure;

public static class DependencyInjection
{
    public static void ConfigureAdmInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.ConfigureServiceInfrastructure();
   /*     services.AddScoped<IIdentityProvider, KeycloakIdentityProvider>();
        services.AddScoped<IPermissionResolver, PermissionResolver>();*/
        services.ConfigureSdks();
        services.ConfigureRabbitMQ(config);
        services.AddMinIO(InfrastructureSettings.InfrastructureInstance.WbMinio);
    }
}
