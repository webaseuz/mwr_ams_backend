using Bms.Core.Domain.Domains;

namespace Bms.Core.Domain.Events;

public class StatusChangedEvent<TId> :
    IDomainEvent
    where TId : struct
{
    public TId OwnerId { get; set; }
    public int StatusId { get; }
    public string Message { get; }
    public string DataAsJson { get; }
    public DateTime OccurredOn { get; }

    public StatusChangedEvent(TId ownerId,
                              int statusId,
                              string message,
                              string dataAsJson)
    {
        OwnerId = ownerId;
        StatusId = statusId;
        Message = message;
        DataAsJson = dataAsJson;
        OccurredOn = DateTime.Now;
    }
}
