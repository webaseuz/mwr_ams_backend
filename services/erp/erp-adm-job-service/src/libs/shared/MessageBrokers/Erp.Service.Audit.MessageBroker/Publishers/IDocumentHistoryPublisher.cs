using Erp.Service.Audit.MessageBroker.QueueMessages;
using WEBASE.MessageBroker.Abstraction;

namespace Erp.Service.Audit.MessageBroker.Publishers
{
    public interface IDocumentHistoryPublisher : IWbPublisher<DocumentHistoryMessage>
    {

    }
}
