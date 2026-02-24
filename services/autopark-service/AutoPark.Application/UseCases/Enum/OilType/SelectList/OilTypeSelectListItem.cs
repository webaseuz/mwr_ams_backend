using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.OilTypes;

public class OilTypeSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
