using Erp.Core.Security;
using Erp.Core.Service.Infrastructure;
using Erp.Service.Adm.Job.Application;
using Erp.Service.Adm.Job.WebApi;
using WEBASE;
using WEBASE.i18n;

namespace Microsoft.Extensions.DependencyInjection;

public static class AuthServiceExtentions
{
    public static void ConfigureAuthServices(this IServiceCollection services)
    {
        services.AddScoped<IMainAuthService, MainAuthService>();
        services.AddScoped<IAuthService>(x => x.GetService<IMainAuthService>());
        services.AddScoped<IWbAuthService>(x => x.GetService<IMainAuthService>());
        services.AddScoped<ICultureHelper, CultureHelper>();
    }
}
