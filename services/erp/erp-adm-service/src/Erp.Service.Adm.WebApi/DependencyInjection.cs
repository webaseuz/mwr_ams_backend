namespace Erp.Service.Adm.WebApi;

public static class DependencyInjection
{
    public static void ConfigureAdmWebApi(this IServiceCollection services)
    {
        services.ConfigureConfigs();
        services.AddServiceSwagger();
    }
}
