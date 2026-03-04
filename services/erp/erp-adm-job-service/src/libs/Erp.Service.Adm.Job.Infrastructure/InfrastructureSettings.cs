using Erp.Core.Sdk;
using Erp.Core.Service.Infrastructure;
using WEBASE.Storage.MinIO;

namespace Erp.Service.Adm.Job.Infrastructure;

public class InfrastructureSettings : ServiceAppSettings
{
    public static InfrastructureSettings InfrastructureInstance { get; private set; }

    public SdkConfigs Sdks { get; set; } = new();
    public IdpConfig Idp { get; set; } = new();
    //public WbMinioConfig WbMinio { get; set; } = new();

    public static void Init(InfrastructureSettings instance)
    {
        InfrastructureInstance = instance;
        ServiceAppSettings.Init(instance);
    }
    public class SdkConfigs
    {
        public SdkConfig ItgProxySdk { get; set; }
        public SdkConfig AdmSdk { get; set; }
    }
}
