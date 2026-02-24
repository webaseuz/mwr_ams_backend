using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.TransportModelFiles;

public class TransportModelFileSelectListItem<TValue> : SelectListItem<TValue>
{
    public int? TransportModelId { get; set; }
    public int? TransportColorId { get; set; }
}