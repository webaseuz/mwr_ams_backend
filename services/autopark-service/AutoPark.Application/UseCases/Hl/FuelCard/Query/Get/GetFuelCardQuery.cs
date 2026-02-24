using MediatR;

namespace AutoPark.Application.UseCases.FuelCards;

public class GetFuelCardQuery :
    IRequest<FuelCardDto>
{
}
