using MediatR;

namespace AutoPark.Application.UseCases.Info.BatteryTypes
{
    public class GetBatteryTypeQuery : IRequest<BatteryTypeDto>
    { }
}
