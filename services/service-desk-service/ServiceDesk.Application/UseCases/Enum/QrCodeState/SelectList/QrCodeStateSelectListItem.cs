using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Enum.QrCodeStates;

public class QrCodeStateSelectListItem<TValue> : SelectListItem<TValue>
{
    public string FullName { get; set; }
}
