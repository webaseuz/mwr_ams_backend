using Erp.Service.Adm.RabbitMQ.Queues;
using Erp.Service.Audit.MessageBroker.Publishers;
using Erp.Service.Audit.MessageBroker.QueueMessages;
using Microsoft.Extensions.Logging;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Audit.RabbitMQ.Publishers;

public class RowHistoryPublisher : WbRabbitMQPublisher<RowHistoryMessage>, IRowHistoryPublisher
{
    public RowHistoryPublisher(IWbRabbitMQPublisherClient client, ILogger<WbRabbitMQPublisher<RowHistoryMessage>> logger) : base(client, logger, AuditQueues.RowHistory)
    {
    }
}
