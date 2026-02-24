using Bms.WEBASE.Helpers;
using Bms.WEBASE.Storage;
using WEBASE.Security.Abstraction;

namespace Bms.WEBASE.DependencyInjection;

public class BaseAsyncServiceProvider<TAuthService> :
        BaseServiceProvider
        where TAuthService : IBaseAuthService
{
    public static TAuthService AuthService
        => GetService<TAuthService>();

    public static IStorageAsyncService StorageService
        => GetService<IStorageAsyncService>();

    public static ICultureHelper CultureHelper
        => GetService<ICultureHelper>();
}

public class BaseServiceProvider
{
    private static Func<IServiceProvider> _serviceProviderAccessor;

    public static void Initialize(Func<IServiceProvider> serviceProviderAccessor)
        => _serviceProviderAccessor = serviceProviderAccessor;

    public static TService GetService<TService>()
        => (TService)GetService(typeof(TService));

    protected static object GetService(Type serviceType)
        => _serviceProviderAccessor().GetService(serviceType);

}
