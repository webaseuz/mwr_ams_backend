using MediatR;

namespace AutoPark.Application.UseCases.Regions;

public class GetRegionByIdQuery :
    IRequest<RegionDto>
{
    public int Id { get; set; }
}
