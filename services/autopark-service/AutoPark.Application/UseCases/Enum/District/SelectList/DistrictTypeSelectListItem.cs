using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Districts;

public class DistrictTypeSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}

