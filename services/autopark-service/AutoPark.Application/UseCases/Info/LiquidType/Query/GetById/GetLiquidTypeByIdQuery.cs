using MediatR;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class GetLiquidTypeByIdQuery :
     IRequest<LiquidTypeDto>
{
    public int Id { get; set; }
}
