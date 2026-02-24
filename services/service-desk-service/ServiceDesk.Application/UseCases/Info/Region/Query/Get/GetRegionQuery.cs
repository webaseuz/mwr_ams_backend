using MediatR;

namespace ServiceDesk.Application.UseCases.Regions;

public class GetRegionQuery :
	IRequest<RegionDto>
{

}
