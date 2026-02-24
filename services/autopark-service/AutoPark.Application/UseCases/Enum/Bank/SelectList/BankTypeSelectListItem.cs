using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Banks;

public class BankTypeSelectListItem<TValue> : SelectListItem<TValue>
{
    public string BankCode { get; set; }

}
