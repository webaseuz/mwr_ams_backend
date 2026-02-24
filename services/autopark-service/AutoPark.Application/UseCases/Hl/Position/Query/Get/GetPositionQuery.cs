using MediatR;

namespace AutoPark.Application.UseCases.Positions;

public class GetPositionQuery :
    IRequest<PositionDto>
{
}
