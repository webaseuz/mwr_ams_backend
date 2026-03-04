using WEBASE.MessageBroker.Abstraction;

namespace Erp.Service.Adm.MessageBroker.QueueMessages;

public class UserLastVisitMessage : IWbQueueMessage
{
    public int UserId { get; set; }
    public int LastVisitAppId { get; set; }
    public DateTime LastVisitAt { get; set; }
}
