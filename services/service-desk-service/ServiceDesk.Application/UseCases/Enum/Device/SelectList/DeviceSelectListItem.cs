using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Devices;

public class DeviceSelectListItem<TValue> : SelectListItem<TValue>
{ 
    public string SerialNumber { get; set; }
    public long? ManufacturerId { get; set; }
}