using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Enum.Statuses;

public class StatusSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
