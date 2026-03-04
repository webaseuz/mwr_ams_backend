using Erp.Core;

namespace Erp.Adm.Bff.Web.WebApi;

public static class ConfigServiceExtensions
{
    public static void ConfigureConfigs(this IServiceCollection services)
    {
        services.AddSingleton(new AppInfoConfig(AppIdConst.ADM, AppType.BFF));
    }
}
