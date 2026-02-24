using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Enum.States;

public class StateSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
