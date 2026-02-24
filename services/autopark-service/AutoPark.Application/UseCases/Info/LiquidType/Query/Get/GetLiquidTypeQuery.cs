using MediatR;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class GetLiquidTypeQuery :
    IRequest<LiquidTypeDto>
{
}
