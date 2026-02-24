using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.TransportModels;

public class TransportModelSelectListItem<TValue> : SelectListItem<TValue>
{
    public int TransportTypeId { get; set; }
}