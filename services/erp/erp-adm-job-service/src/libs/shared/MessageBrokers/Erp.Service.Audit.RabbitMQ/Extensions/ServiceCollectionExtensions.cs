using Erp.Service.Audit.MessageBroker.Publishers;
using Erp.Service.Audit.MessageBroker.QueueMessages;
using Erp.Service.Audit.RabbitMQ.Publishers;
using Microsoft.Extensions.DependencyInjection;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Audit.RabbitMQ.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuditPublishers(this IServiceCollection services)
    {
        services.AddPublisher<DocumentHistoryMessage, DocumentHistoryPublisher>();
        services.AddPublisher<RowHistoryMessage, RowHistoryPublisher>();

        services.AddScoped<IDocumentHistoryPublisher, DocumentHistoryPublisher>();
        services.AddScoped<IRowHistoryPublisher, RowHistoryPublisher>();

        return services;
    }
}
