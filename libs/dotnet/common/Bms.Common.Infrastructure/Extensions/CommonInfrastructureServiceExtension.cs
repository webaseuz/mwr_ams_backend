using Microsoft.Extensions.DependencyInjection;
using WEBASE.Security;
using WEBASE.Security.Abstraction;

namespace WEBASE.Extension;

public static class CommonInfrastructureServiceExtension
{
    public static void AddCommonInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IEncryptionService, AesEncryptionService>();
    }
}