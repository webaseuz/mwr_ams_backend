namespace Erp.Service.Adm.Job.WebApi;

public static class DependencyInjection
{
    public static void ConfigureAdmJobWebApi(this IServiceCollection services)
    {
        services.ConfigureConfigs();
        services.AddServiceSwagger();

    }
}
