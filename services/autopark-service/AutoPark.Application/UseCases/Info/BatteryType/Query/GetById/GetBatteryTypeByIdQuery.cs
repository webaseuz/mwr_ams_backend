using MediatR;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class GetBatteryTypeByIdQuery :
    IRequest<BatteryTypeDto>
{
    public int Id { get; set; }
}
