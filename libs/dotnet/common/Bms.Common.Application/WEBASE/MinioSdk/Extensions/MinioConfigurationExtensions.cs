using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Storage;

namespace Microsoft.Extensions.DependencyInjection;

public static class MinioConfigurationExtensions
{
    public static IServiceCollection AddMinioCLient(this IServiceCollection services, MinioConfig config)
    {
        services.AddSingleton(config);

        services.AddSingleton<FileStorageConfig>(config);

        if (config.IsSingletonClient)
            services.AddSingleton<MinioStorageClient>();
        else
            services.AddScoped<MinioStorageClient>();

        services.AddScoped<IStorageAsyncService, MinioStorageAsyncService>();

        return services;
    }
}
