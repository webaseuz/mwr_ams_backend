using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Enum.QrCodeStates;

public class QrCodeStateSelectListItem<TValue> : SelectListItem<TValue>
{
    public string FullName { get; set; }
}
