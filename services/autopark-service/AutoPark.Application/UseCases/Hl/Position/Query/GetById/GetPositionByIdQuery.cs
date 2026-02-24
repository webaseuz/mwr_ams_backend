using MediatR;

namespace AutoPark.Application.UseCases.Positions;

public class GetPositionByIdQuery :
    IRequest<PositionDto>
{
    public int Id { get; set; }
}
