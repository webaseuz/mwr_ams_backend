using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WEBASE.Extension.Abstraction;

namespace WEBASE.Extension;

public static class GrpcExtensions
{
    public static IServiceCollection AddGrpcStreamHandlers(this IServiceCollection services,
                                                           Assembly assembly)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
        .Where(a => !a.IsDynamic)
        .ToList();

        var grpcHandlerTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(type => !type.IsAbstract && !type.IsInterface)
            .SelectMany(type => type.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IGrpcStreamHandler<,>))
                .Select(i => new { ServiceType = i, ImplementationType = type }))
            .ToList();

        foreach (var handlerType in grpcHandlerTypes)
            services.AddScoped(handlerType.ServiceType, handlerType.ImplementationType);

        return services;
    }
}
