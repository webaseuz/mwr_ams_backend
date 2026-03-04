using System.Reflection;
using Erp.Core.Models;
using Erp.Service.Adm.Models;
using MediatR;

namespace Erp.Service.Adm.Application.Extensions;

public static class DocumentChangeLogServiceExtensions
{
    #region AdmRowChangeLog
    /// <summary>
    /// Barcha ISysEntity ni implement qilgan DTO lar uchun avtomatik handler registratsiya qiladi
    /// </summary>

    public static IServiceCollection RegisterAllRowChangeLogHandlers(
        this IServiceCollection services,
        Assembly modelsAssembly = null)
    {
        // Agar assembly ko'rsatilmagan bo'lsa, Models assembly ni ishlat
        modelsAssembly ??= typeof(RowChangeLogCreateCommand<,>).Assembly;

        // IDocumentEntity<TId> ni implement qilgan barcha classlarni top
        var documentEntityTypes = modelsAssembly.GetTypes()
            .Where(t => t.IsClass &&
                       !t.IsAbstract &&
                       t.GetInterfaces().Any(i => i.IsGenericType &&
                                                  i.GetGenericTypeDefinition() == typeof(ISysEntity<>)))
            .ToList();

        Console.WriteLine($"[DocumentChangeLog] Found {documentEntityTypes.Count} document entities:");

        foreach (var entityType in documentEntityTypes)
        {
            // IDocumentEntity<TId> dan TId ni ol
            var documentEntityInterface = entityType.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISysEntity<>));

            var idType = documentEntityInterface.GetGenericArguments()[0];

            // Generic type larni yarat
            var commandType = typeof(RowChangeLogCreateCommand<,>).MakeGenericType(idType, entityType);
            var handlerType = typeof(RowChangeLogCreateCommandHandler<,>).MakeGenericType(idType, entityType);
            var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(commandType, typeof(bool));

            // Register qil
            services.AddTransient(requestHandlerType, handlerType);

            Console.WriteLine($"  ✓ Registered: {entityType.Name} (ID: {idType.Name})");
        }

        return services;
    }

    /// <summary>
    /// Bitta DTO uchun handler registratsiya qiladi (Type-safe)
    /// </summary>
    public static IServiceCollection RegisterRowChangeLogHandler<TId, TEntity>(
        this IServiceCollection services)
        where TId : struct
        where TEntity : ISysEntity<TId>
    {
        services.AddTransient<
            IRequestHandler<RowChangeLogCreateCommand<TId, TEntity>, bool>,
            RowChangeLogCreateCommandHandler<TId, TEntity>>();

        return services;
    }

    /// <summary>
    /// Ko'p DTO lar uchun handler registratsiya qiladi (Batch registration)
    /// </summary>
    public static IServiceCollection RegisterRowChangeLogHandlers(
        this IServiceCollection services,
        params Type[] entityTypes)
    {
        foreach (var entityType in entityTypes)
        {
            // Check if type implements IDocumentEntity<TId>
            var documentEntityInterface = entityType.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDocumentEntity<>));

            if (documentEntityInterface == null)
            {
                Console.WriteLine($"  ⚠ Skipped: {entityType.Name} (doesn't implement IDocumentEntity)");
                continue;
            }

            var idType = documentEntityInterface.GetGenericArguments()[0];

            var commandType = typeof(RowChangeLogCreateCommand<,>).MakeGenericType(idType, entityType);
            var handlerType = typeof(RowChangeLogCreateCommandHandler<,>).MakeGenericType(idType, entityType);
            var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(commandType, typeof(bool));

            services.AddTransient(requestHandlerType, handlerType);
        }

        return services;
    }
    #endregion
}
