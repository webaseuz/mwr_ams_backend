using MediatR;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class GetLiquidTypeQueryHandler :
     IRequestHandler<GetLiquidTypeQuery, LiquidTypeDto>
{
    public Task<LiquidTypeDto> Handle(
        GetLiquidTypeQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new LiquidTypeDto());
}
