using MediatR;

namespace ServiceDesk.Application.UseCases.Regions;

public class GetRegionByIdQuery :
	IRequest<RegionDto>
{
	public int Id { get; set; }
}
