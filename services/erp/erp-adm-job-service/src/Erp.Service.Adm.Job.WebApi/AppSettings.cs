using Erp.Service.Adm.Job.Infrastructure;
using WEBASE.AppError.Abstraction;

namespace Erp.Service.Adm.Job.WebApi;

public class AppSettings : InfrastructureSettings
{
    public static AppSettings Instance { get; private set; }
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
