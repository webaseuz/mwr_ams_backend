using Erp.Service.Adm.MessageBroker.Publishers;
using Erp.Service.Adm.MessageBroker.QueueMessages;
using Erp.Service.Adm.RabbitMQ.Queues;
using Microsoft.Extensions.Logging;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Adm.RabbitMQ.Publishers;

public class CustomJobPublisher : WbRabbitMQPublisher<CustomJobMessage>, ICustomJobPublisher
{
    public CustomJobPublisher(IWbRabbitMQPublisherClient client, ILogger<WbRabbitMQPublisher<CustomJobMessage>> logger) : base(client, logger, AdmQueues.CustomJob)
    {
    }
}
