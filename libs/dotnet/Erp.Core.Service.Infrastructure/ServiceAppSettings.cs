using WEBASE.i18n;

namespace Erp.Core.Service.Infrastructure;

public class ServiceAppSettings
{
    public static ServiceAppSettings ServiceInstance { get; set; }
    public DatabaseConfig Database { get; set; } = new();
    public CultureConfig Culture { get; set; } = new();

    public static void Init(ServiceAppSettings instance)
    {
        ServiceInstance = instance;
    }
}
