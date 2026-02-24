using MediatR;

namespace AutoPark.Application.UseCases.Refuels;

public class GetRefuelQuery :
    IRequest<RefuelDto>
{
}
