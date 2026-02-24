using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Banks;

public class BankTypeSelectListItem<TValue> : SelectListItem<TValue>
{
	public string BankCode { get; set; }

}
