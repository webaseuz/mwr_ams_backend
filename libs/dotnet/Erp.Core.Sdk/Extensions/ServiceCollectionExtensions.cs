using System.Text.Json;
using Erp.Core.Sdk.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Erp.Core.Sdk;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSdkHandlers(this IServiceCollection services, SdkConfig config)
    {
        // Register the language header handler
        services.AddTransient<LanguageHeaderHandler>();
        services.AddTransient<UserHeaderHandler>();
        services.AddTransient<ApiErrorHandler>();
        services.AddTransient<AppHeaderHandler>();

        return services;
    }

    public static void RegisterApiClient<T>(this IServiceCollection services, SdkConfig config, RefitSettings refitSettings = null)
        where T : class
    {
        if(refitSettings == null)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                Converters = {
                    new Erp.Core.Extensions.SmartDateTimeConverterFactory(),
                    new Erp.Core.Extensions.SmartDateOnlyConverterFactory()
                },
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };

            refitSettings = new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(jsonOptions)
            };
        }

        services.AddRefitClient<T>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(config.BaseUrl))
            .AddHttpMessageHandler<LanguageHeaderHandler>()
            .AddHttpMessageHandler<UserHeaderHandler>()
            .AddHttpMessageHandler<ApiErrorHandler>()
            .AddHttpMessageHandler<AppHeaderHandler>();
    }
}
