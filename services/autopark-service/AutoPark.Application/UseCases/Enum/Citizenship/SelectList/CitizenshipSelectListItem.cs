using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Citizenships;

public class CitizenshipSelectListItem<TValue> : SelectListItem<TValue>
{
    public bool IsCitizenship { get; set; }
}
