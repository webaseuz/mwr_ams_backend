using MediatR;

namespace ServiceDesk.Application.UseCases.Positions;

public class GetPositionQueryHandler :
	IRequestHandler<GetPositionQuery, PositionDto>
{
	public Task<PositionDto> Handle(
		GetPositionQuery request,
		CancellationToken cancellationToken)
		=> Task.FromResult(new PositionDto());

}
