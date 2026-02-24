using MediatR;

namespace AutoPark.Application.UseCases.Districts;

public class GetDistrictByIdQuery :
    IRequest<DistrictDto>
{
    public int Id { get; set; }
}
