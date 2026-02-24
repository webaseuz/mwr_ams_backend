using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Enum.TransportTypes;

public class TransportTypeSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
