using MediatR;

namespace ServiceDesk.Application.UseCases.Districts;

public class GetDistrictByIdQuery :
    IRequest<DistrictDto>
{
    public int Id { get; set; }
}
