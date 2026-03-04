using WEBASE.i18n;
using Erp.Adm.Bff.Web.Infrastructure;

namespace Erp.Adm.Bff.Web.WebApi;

public class AppSettings : InfrastructureSettings
{
    public static AppSettings Instance { get; private set; }
    public IdpConfig Idp { get; set; } = new();
    public SwaggerConfig Swagger { get; set; } = new();
    public CultureConfig Culture { get; set; } = new();
    public CorsConfig Cors { get; set; } = new();
    public OneIdConfig OneId { get; set; } = new();
    public static void Init(AppSettings instance)
    {
        InfrastructureSettings.Init(instance);
        Instance = instance;
    }

}

public class IdpConfig
{
    public string BaseUrl { get; set; }
    public string Realm { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}

public class SwaggerConfig
{
    public bool Enabled { get; set; }
    public string Prefix { get; set; }
    public string IdpClientId { get; set; }
}

public class CorsConfig
{
    public bool UseCors { get; set; }
    public string AllowedOrgins { get; set; }
}
public class OneIdConfig
{
    public string BaseUri { get; set; }
    public string ClientId { get; set; }
    public string Secret { get; set; }
    public string RedirectUri { get; set; }
    public string Scope { get; set; }
}
