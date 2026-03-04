using Erp.Service.Adm.Infrastructure;
using WEBASE.AppError.Abstraction;

namespace Erp.Service.Adm.WebApi;

public class AppSettings : InfrastructureSettings
{
    public static AppSettings Instance { get; set; }
    public SwaggerConfig Swagger { get; set; } = new();
    public WbAppErrorConfig AppError { get; set; } = new();
    public static void Init(AppSettings instance)
    {
        Instance = instance;
        InfrastructureSettings.Init(instance);
    }
}
public class SwaggerConfig
{
    public bool Enabled { get; set; }
    public string Prefix { get; set; }
}
