namespace ServiceDesk.WebApi;

public static class ConfigServiceExtension
{
    public static void ConfigureConfigs(this IServiceCollection services)
    {
        services.AddSingleton(AppSettings.Instance.Culture);
        services.AddSingleton(AppSettings.Instance.ReferenceToken);
        services.AddSingleton(AppSettings.Instance.Encryption);
        services.AddSingleton(AppSettings.Instance.KestrelCustom);
        services.AddSingleton(AppSettings.Instance.ClientErrors);
        services.AddSingleton(AppSettings.Instance.Cors);
        services.AddSingleton(AppSettings.Instance.Culture);
        services.AddSingleton(AppSettings.Instance.Database);
        services.AddSingleton(AppSettings.Instance.Database.PgSql);
        services.AddSingleton(AppSettings.Instance.Swagger);
    }
}