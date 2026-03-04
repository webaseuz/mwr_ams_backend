using Erp.Service.Adm.MessageBroker.Publishers;
using Erp.Service.Adm.MessageBroker.QueueMessages;
using Erp.Service.Adm.RabbitMQ.Queues;
using Microsoft.Extensions.Logging;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Adm.RabbitMQ.Publishers;

public class SyncUserWithEmployeePublisher : WbRabbitMQPublisher<SyncUserWithEmployeeMessage>, ISyncUserWithEmployeePublisher
{
    public SyncUserWithEmployeePublisher(IWbRabbitMQPublisherClient client, ILogger<WbRabbitMQPublisher<SyncUserWithEmployeeMessage>> logger) : base(client, logger, AdmQueues.SyncUserWithEmployee)
    {
    }
}
