using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Enum.QrCodeTypes;

public class QrCodeTypeSelectListItem<TValue> : SelectListItem<TValue>
{
    public string FullName { get; set; }
}
