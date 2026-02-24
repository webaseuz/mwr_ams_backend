using Bms.Core.Domain;
using Bms.WEBASE.Config;
using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Security;
using WEBASE.Security;

namespace ServiceDesk.MobileApi;

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
    //public LogSdkConfiguration LogSdk { get; set; }
    //public JaegerConfig Jaeger { get; set; } = new();
    public ClientErrorsConfig ClientErrors { get; set; } = new();
    public MinioConfig Minio { get; set; } = new();
}