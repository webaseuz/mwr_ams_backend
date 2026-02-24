using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.TireModels;

public class TireModelSelectListItem<TValue> : SelectListItem<TValue>
{
    public string FullName { get; set; }
}
