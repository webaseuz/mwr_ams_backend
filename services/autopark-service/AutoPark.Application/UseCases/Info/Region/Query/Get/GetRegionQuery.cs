using MediatR;

namespace AutoPark.Application.UseCases.Regions;

public class GetRegionQuery :
    IRequest<RegionDto>
{
}
