using ServiceDesk.Application.Security;
using ServiceDesk.Infrastructure.Security;
using Bms.Core.Application;
using Bms.Core.Infrastructure;
using Bms.WEBASE.Helpers;
using Bms.WEBASE.Security;
using Microsoft.Extensions.DependencyInjection;
using WEBASE.Security;
using WEBASE.Security.Abstraction;
using ServiceDesk.Application;

namespace ServiceDesk.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDateTimeHelper, DateTimeHelper>();
        services.AddScoped<IUserDeviceProvider, UserDeviceProvider>();
        services.AddScoped<ITokenProvider, TokenProvider>();
        services.AddScoped<IAsyncAppTokenService, AsyncAppTokenService>(); 
        services.AddScoped<IAsyncAppAuthService, AppAuthService>();
        services.AddScoped<IBaseAuthService, AppAuthService>();
        services.AddScoped<IAsyncRefreshableReferenceTokenService, AsyncAppTokenService>();
        services.AddScoped<ICultureHelper, CultureHelper>();
        services.AddScoped<IEncryptionService, AesEncryptionService>();
        services.AddScoped<INumberService, NumberService>();

        return services;
    }
}
