using Erp.Service.Adm.RabbitMQ.Queues;
using Erp.Service.Audit.MessageBroker.Publishers;
using Erp.Service.Audit.MessageBroker.QueueMessages;
using Microsoft.Extensions.Logging;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Audit.RabbitMQ.Publishers;

public class DocumentHistoryPublisher : WbRabbitMQPublisher<DocumentHistoryMessage>, IDocumentHistoryPublisher
{
    public DocumentHistoryPublisher(IWbRabbitMQPublisherClient client, ILogger<WbRabbitMQPublisher<DocumentHistoryMessage>> logger) : base(client, logger, AuditQueues.DocumentHistory)
    {
    }
}
