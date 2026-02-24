using Bms.Core.Domain;
using Bms.WEBASE.Config;
using Bms.WEBASE.Security;
using WEBASE.Jaeger;
using WEBASE.LogSdk;
using WEBASE.Security;

namespace Bms.Bff.Web.WebApi;

public class AppSettings
{
    public static AppSettings Instance { get; private set; }

    public static void Init(AppSettings instance)
        => Instance = instance;

    // Existing BMS configurations (preserving YOUR superior auth)
    public EncryptionConfig Encryption { get; set; } = new();
    public RefreshableReferenceTokenConfig ReferenceToken { get; set; } = new();
    public KestrelConfig KestrelCustom { get; set; } = new();
    public CultureConfig Culture { get; set; } = new();
    public SwaggerConfig Swagger { get; set; } = new();
    public CorsConfig Cors { get; set; } = new();
    public LogSdkConfiguration LogSdk { get; set; }
    public ClientErrorsConfig ClientErrors { get; set; } = new();
    public JaegerConfig Jaeger { get; set; } = new();
    public BasicAuthConfig BasicAuth { get; set; } = new();

    // New BFF-specific configurations
    public AuthenticationConfig Authentication { get; set; } = new();
    public ServicesConfig Services { get; set; } = new();
    public LocalizationConfig Localization { get; set; } = new();
    public HealthChecksConfig HealthChecks { get; set; } = new();
}

public class AuthenticationConfig
{
    public string DefaultProvider { get; set; } = "BMS-JWT";
    public List<AuthProviderConfig> Providers { get; set; } = new();
}

public class AuthProviderConfig
{
    public string Name { get; set; }
    public string Type { get; set; }
    public bool Enabled { get; set; } = true;
    public Dictionary<string, object> Settings { get; set; } = new();
}

public class ServicesConfig
{
    public ServiceEndpointConfig AutoParkService { get; set; } = new();
    public ServiceEndpointConfig ServiceDeskService { get; set; } = new();
    // Room for future services
    public Dictionary<string, ServiceEndpointConfig> AdditionalServices { get; set; } = new();
}

public class ServiceEndpointConfig
{
    public string BaseUrl { get; set; }
    public string HealthEndpoint { get; set; } = "/health";
    public int Timeout { get; set; } = 30;
    public RetryPolicyConfig RetryPolicy { get; set; } = new();
}

public class RetryPolicyConfig
{
    public int RetryCount { get; set; } = 3;
    public int BackoffMultiplier { get; set; } = 2;
}

public class LocalizationConfig
{
    public string DefaultLanguage { get; set; } = "uz-latn";
    public List<string> SupportedLanguages { get; set; } = new() { "uz-latn", "uz-cyrl", "ru", "en" };
    public string ResourcePath { get; set; } = "Resources";
}

public class HealthChecksConfig
{
    public string UIPath { get; set; } = "/health-ui";
    public int CheckInterval { get; set; } = 30;
    public int HealthCheckTimeout { get; set; } = 10;
    public List<HealthCheckEndpoint> Services { get; set; } = new();
}

public class HealthCheckEndpoint
{
    public string Name { get; set; }
    public string Url { get; set; }
    public bool Critical { get; set; } = true;
}