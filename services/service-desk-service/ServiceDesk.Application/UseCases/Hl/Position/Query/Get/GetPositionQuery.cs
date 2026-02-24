using MediatR;

namespace ServiceDesk.Application.UseCases.Positions;

public class GetPositionQuery :
	IRequest<PositionDto>
{
}
