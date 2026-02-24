using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Enum.QrCodeTypes;

public class QrCodeTypeSelectListItem<TValue> : SelectListItem<TValue>
{
    public string FullName { get; set; }
}
