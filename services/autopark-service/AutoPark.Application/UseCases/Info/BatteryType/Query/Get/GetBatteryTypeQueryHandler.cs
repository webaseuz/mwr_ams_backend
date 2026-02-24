using MediatR;

namespace AutoPark.Application.UseCases.Info.BatteryTypes
{
    public class GetBatteryTypeQueryHandler :
        IRequestHandler<GetBatteryTypeQuery, BatteryTypeDto>
    {
        public Task<BatteryTypeDto> Handle(
           GetBatteryTypeQuery request,
           CancellationToken cancellationToken)
           => Task.FromResult(new BatteryTypeDto());
    }
}
