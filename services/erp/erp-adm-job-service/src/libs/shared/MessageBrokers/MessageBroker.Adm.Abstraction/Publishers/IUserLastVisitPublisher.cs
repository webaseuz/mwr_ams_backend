using Erp.Service.Adm.MessageBroker.QueueMessages;
using WEBASE.MessageBroker.Abstraction;

namespace Erp.Service.Adm.MessageBroker.Publishers;

public interface IUserLastVisitPublisher : IWbPublisher<UserLastVisitMessage>
{
}
