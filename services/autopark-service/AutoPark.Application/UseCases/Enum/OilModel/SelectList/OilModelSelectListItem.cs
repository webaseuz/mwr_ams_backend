using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.OilModels;

public class OilModelSelectListItem<TValue> : SelectListItem<TValue>
{
    public string FullName { get; set; }
}
