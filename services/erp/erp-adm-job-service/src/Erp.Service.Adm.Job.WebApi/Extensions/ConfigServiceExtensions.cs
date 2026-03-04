using Erp.Core;

namespace Erp.Service.Adm.Job.WebApi;

public static class ConfigServiceExtensions
{
    public static void ConfigureConfigs(this IServiceCollection services)
    {
        services.AddSingleton(new AppInfoConfig(AppIdConst.ADM, AppType.JOB));
    }
}
