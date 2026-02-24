using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class DeviceSpareTypeSelectListItem<TValue> : SelectListItem<TValue>
{
    public int Quantity { get; set; } = 0;
    public string Nomenclature { get; set; }
}

