using WEBASE.MessageBroker.Abstraction;

namespace Erp.Service.Adm.MessageBroker.QueueMessages;

public record CustomJobMessage : IWbQueueMessage
{
    public long DocId { get; set; }
    public int TableId { get; set; }
    public int? FromStatusId { get; set; }
    public int ToStatusId { get; set; }
}
