using Bms.Core.Domain;
using Bms.WEBASE.Config;
using Bms.WEBASE.Security;

namespace AutoPark.Jobs;

public class AppSettings
{
    public static AppSettings Instance { get; private set; }

    public DatabaseConfig Database { get; set; } = new();
    public QuartzConfig QuartzDriverPenaltyNotification { get; set; } = new QuartzConfig();
    public RefreshableReferenceTokenConfig ReferenceToken { get; set; } = new();
    public CorsConfig Cors { get; set; } = new();
    //public SwaggerConfig Swagger { get; set; } = new();
    public static void Init(AppSettings instance)
    {
        Instance = instance;
    }
}