using Erp.Core;

namespace Erp.Service.Adm.WebApi;

public static class ConfigServiceExtensions
{
    public static void ConfigureConfigs(this IServiceCollection services)
    {
        services.AddSingleton(new AppInfoConfig(AppIdConst.ADM, AppType.SERVICE));
    }
}
