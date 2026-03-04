using Erp.Adm.Bff.Web.Application;
using Erp.Core.Sdk;
using Erp.Core.Security;
using WEBASE;

namespace Erp.Adm.Bff.Web.WebApi;

public static class AuthServiceExtensions
{
    public static void ConfigureAuthService(this IServiceCollection services)
    {
        services.AddScoped<IMainAuthService, MainAuthService>();
        services.AddScoped<IWbAuthService>(x => x.GetService<IMainAuthService>());
    }
}
