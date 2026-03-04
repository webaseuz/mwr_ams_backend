using Erp.Service.Adm.Sdk;
using Erp.Service.Hrm.Sdk;
using Erp.Service.Itg.Proxy.Sdk;
using Erp.Service.My.Sdk;
using Microsoft.Extensions.DependencyInjection;

namespace Erp.Adm.Bff.Web.Infrastructure;

public static class SdkServiceExtensions
{
    public static void ConfigureSdks(this IServiceCollection services)
    {
        services.ConfigureAdmSdk(InfrastructureSettings.InfrastructureInstance.Sdks.AdmSdk);
        services.ConfigureItgProxySdk(InfrastructureSettings.InfrastructureInstance.Sdks.ItgProxySdk);
        services.ConfigureHrmSdk(InfrastructureSettings.InfrastructureInstance.Sdks.HrmSdk);
        services.ConfigureMySdk(InfrastructureSettings.InfrastructureInstance.Sdks.MySdk);
    }
}
