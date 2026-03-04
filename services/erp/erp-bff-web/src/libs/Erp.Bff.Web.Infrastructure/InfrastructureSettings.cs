using Erp.Core.Sdk;

namespace Erp.Adm.Bff.Web.Infrastructure;

public class InfrastructureSettings
{
    public static InfrastructureSettings InfrastructureInstance { get; private set; }
    public SdkConfigs Sdks { get; set; } = new();

    public static void Init(InfrastructureSettings instance)
    {
        InfrastructureInstance = instance;
    }
}

public class SdkConfigs
{
    public SdkConfig AdmSdk { get; set; }
    public SdkConfig ItgProxySdk { get; set; }
    public SdkConfig HrmSdk { get; set; }
    public SdkConfig MySdk { get; set; }
}
