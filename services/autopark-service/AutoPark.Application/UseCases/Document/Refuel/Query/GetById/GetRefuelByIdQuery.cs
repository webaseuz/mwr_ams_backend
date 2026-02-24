using MediatR;

namespace AutoPark.Application.UseCases.Refuels;

public class GetRefuelByIdQuery :
    IRequest<RefuelDto>
{
    public long Id { get; set; }
}
