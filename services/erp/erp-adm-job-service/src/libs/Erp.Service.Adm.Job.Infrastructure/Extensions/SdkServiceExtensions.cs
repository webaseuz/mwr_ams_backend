using Erp.Service.Adm.Sdk;
using Erp.Service.Itg.Proxy.Sdk;
using Microsoft.Extensions.DependencyInjection;

namespace Erp.Service.Adm.Job.Infrastructure;

public static class SdkServiceExtensions
{
    public static void ConfigureSdks(this IServiceCollection services)
    {
        services.ConfigureAdmSdk(InfrastructureSettings.InfrastructureInstance.Sdks.AdmSdk);
        services.ConfigureItgProxySdk(InfrastructureSettings.InfrastructureInstance.Sdks.ItgProxySdk);
    }
}
