using Microsoft.Extensions.DependencyInjection;

namespace Bms.Bff.Web.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddBffInfrastructure(this IServiceCollection services)
    {
        // Add HTTP client factory
        services.AddHttpClient();

        // Add memory cache for performance
        services.AddMemoryCache();

        // Add distributed cache (can be replaced with Redis later)
        services.AddDistributedMemoryCache();

        // Add HttpContext accessor for header propagation
        services.AddHttpContextAccessor();

        return services;
    }
}