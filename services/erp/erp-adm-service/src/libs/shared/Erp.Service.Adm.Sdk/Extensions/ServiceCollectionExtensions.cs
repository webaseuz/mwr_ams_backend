using Erp.Core.Sdk;
using Microsoft.Extensions.DependencyInjection;

namespace Erp.Service.Adm.Sdk;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureAdmSdk(this IServiceCollection services, SdkConfig config)
    {
        services.AddSdkHandlers(config);

    /*    services.RegisterApiClient<IAppErrorApi>(config);
        services.RegisterApiClient<IAccountApi>(config);
        services.RegisterApiClient<IBankApi>(config); */

        return services;
    }
}
