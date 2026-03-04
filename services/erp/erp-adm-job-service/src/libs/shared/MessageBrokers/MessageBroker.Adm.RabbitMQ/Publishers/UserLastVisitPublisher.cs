using Erp.Service.Adm.MessageBroker.Publishers;
using Erp.Service.Adm.MessageBroker.QueueMessages;
using Erp.Service.Adm.RabbitMQ.Queues;
using Microsoft.Extensions.Logging;
using WEBASE.MessageBroker.RabbitMQ;

namespace Erp.Service.Adm.RabbitMQ.Publishers;

public class UserLastVisitPublisher : WbRabbitMQPublisher<UserLastVisitMessage>, IUserLastVisitPublisher
{
    public UserLastVisitPublisher(IWbRabbitMQPublisherClient client, ILogger<WbRabbitMQPublisher<UserLastVisitMessage>> logger) : base(client, logger, AdmQueues.UserLastVisit)
    {
    }
}
