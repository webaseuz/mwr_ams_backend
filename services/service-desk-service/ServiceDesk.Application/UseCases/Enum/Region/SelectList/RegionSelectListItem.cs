using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Regions;

public class RegionSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
