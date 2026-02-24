using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Transports;

public class TransportSelectListItem<TValue> :
    SelectListItem<TValue>
{
    public int TransportModelId { get; set; }
    public long? SettingId { get; set; }
}