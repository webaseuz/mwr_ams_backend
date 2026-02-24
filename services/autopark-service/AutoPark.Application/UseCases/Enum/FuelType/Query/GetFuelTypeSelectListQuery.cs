using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.FuelTypes;

public class GetFuelTypeSelectListQuery : IRequest<SelectList<int>>
{
    public long? TransportSettingId { get; set; }
}

