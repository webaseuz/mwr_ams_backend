using Erp.Core.Sdk;
using Erp.Core.Service.Infrastructure;
using WEBASE.Storage.MinIO;

namespace Erp.Service.Adm.Infrastructure;

public class InfrastructureSettings : ServiceAppSettings
{
    public static InfrastructureSettings InfrastructureInstance { get; set; }

    public SdkConfigs Sdks { get; set; } = new();
    public IdpConfig Idp { get; set; } = new();
    public WbMinioConfig WbMinio { get; set; }

    public static void Init(InfrastructureSettings instance)
    {
        InfrastructureInstance = instance;
        ServiceAppSettings.Init(instance);
    }
    public class SdkConfigs
    {
        public SdkConfig ItgProxySdk { get; set; }
    }
}
