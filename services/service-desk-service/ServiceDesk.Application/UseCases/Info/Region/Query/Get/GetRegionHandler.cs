using MediatR;

namespace ServiceDesk.Application.UseCases.Regions;

public class GetRegionHandler :
	IRequestHandler<GetRegionQuery, RegionDto>
{
	public Task<RegionDto> Handle(
		GetRegionQuery request,
		CancellationToken cancellationToken)
		=> Task.FromResult(new RegionDto());
}
