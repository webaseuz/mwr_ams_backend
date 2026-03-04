using WEBASE.MessageBroker.Abstraction;

namespace Erp.Service.Audit.MessageBroker.QueueMessages;

public record DocumentHistoryMessage : IWbQueueMessage
{
    public int UserId { get; set; }
    public string UserInfo { get; set; } = null!;
    public string IpAddress { get; set; }
    public string UserAgent { get; set; }
    public string Message { get; set; }
    public int TableId { get; set; }
    public long DocId { get; set; }
    public int StatusId { get; set; }
    public int OrganizationId { get; set; }
    public long ChangeLogId { get; set; }
    public string DocContent { get; set; }
    public DateTime DateAt { get; set; }
    public string RequestTraceId { get; set; }
}
