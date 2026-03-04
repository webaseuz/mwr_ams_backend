using Microsoft.Extensions.DependencyInjection;

namespace Erp.Service.Adm.Infrastructure;

public static class SdkServiceExtensions
{
    public static void ConfigureSdks(this IServiceCollection services)
    {
        //services.ConfigureItgProxySdk(InfrastructureSettings.InfrastructureInstance.Sdks.ItgProxySdk);
    }
}
