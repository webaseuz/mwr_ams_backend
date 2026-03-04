namespace Erp.Adm.Bff.Web.WebApi;

public static class DependencyInjection
{
    public static void ConfigureWebBffWebApi(this IServiceCollection services)
    {
        services.ConfigureConfigs();
        services.ConfigureAuthService();
        services.ConfigureWebBffAuthentication();
        services.ConfigureWebBffSwagger();
    }
}
