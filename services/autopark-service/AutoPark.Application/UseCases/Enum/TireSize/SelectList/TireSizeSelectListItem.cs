using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.TireSizes;

public class TireSizeSelectListItem<TValue> :
    SelectListItem<TValue>
{
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Diameter { get; set; }
}
