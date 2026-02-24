using MediatR;

namespace ServiceDesk.Application.UseCases.Positions;

public class GetPositionByIdQuery :
	IRequest<PositionDto>
{
	public int Id { get; set; }
}
