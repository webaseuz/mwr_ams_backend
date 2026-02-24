using AutoPark.Application.UseCases.Services.OptimalRouteService;
using AutoPark.Integration;
using Bms.Core.Domain;
using Bms.WEBASE.Config;
using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Security;
using WEBASE.Jaeger;
using WEBASE.LogSdk;
using WEBASE.Security;

namespace AutoPark.WebApi;

public class AppSettings
{
    public static AppSettings Instance { get; private set; }

    public static void Init(AppSettings instance)
        => Instance = instance;

    public EncryptionConfig Encryption { get; set; } = new();
    public RefreshableReferenceTokenConfig ReferenceToken { get; set; } = new();
    public KestrelConfig KestrelCustom { get; set; } = new();
    public CultureConfig Culture { get; set; } = new();
    public DatabaseConfig Database { get; set; } = new();
    public SwaggerConfig Swagger { get; set; } = new();
    public CorsConfig Cors { get; set; } = new();
    public LogSdkConfiguration LogSdk { get; set; }
    public ClientErrorsConfig ClientErrors { get; set; } = new();
    public MinioConfig Minio { get; set; } = new();
    public JaegerConfig Jaeger { get; set; } = new();
    public IntegrationConfig Integration { get; set; } = new IntegrationConfig();
    public BasicAuthConfig BasicAuth { get; set; } = new();
    public OptimalRouteConfig OptimalRoute { get; set; } = new();

    public class IntegrationConfig
    {
        public AutoParkHttpConfig AutoParkHttpConfig { get; set; } = new();
        public AutoParkHttpConfig YhxbbHttpConfig { get; set; } = new();
    }
}