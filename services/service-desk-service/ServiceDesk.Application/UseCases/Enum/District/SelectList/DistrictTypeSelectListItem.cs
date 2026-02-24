using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Districts;

public class DistrictTypeSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}

