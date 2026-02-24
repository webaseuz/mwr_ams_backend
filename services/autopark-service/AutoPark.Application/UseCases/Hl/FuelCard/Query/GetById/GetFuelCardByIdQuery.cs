using MediatR;

namespace AutoPark.Application.UseCases.FuelCards;

public class GetFuelCardByIdQuery :
    IRequest<FuelCardDto>
{
    public int Id { get; set; }
}
