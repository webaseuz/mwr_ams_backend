using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Countries;

public class CountryTypeSelectListItemm<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
