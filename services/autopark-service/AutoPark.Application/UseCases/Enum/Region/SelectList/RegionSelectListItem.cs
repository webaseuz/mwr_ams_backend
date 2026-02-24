using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Regions;

public class RegionSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
