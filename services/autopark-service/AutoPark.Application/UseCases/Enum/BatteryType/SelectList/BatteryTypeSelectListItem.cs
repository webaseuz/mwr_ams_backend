using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.BatteryTypes;

public class BatteryTypeTypeSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
