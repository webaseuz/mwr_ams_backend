using MediatR;

namespace AutoPark.Application.UseCases.FuelCards;

public class GetFuelCardQueryHandler :
    IRequestHandler<GetFuelCardQuery, FuelCardDto>
{
    public Task<FuelCardDto> Handle(
        GetFuelCardQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new FuelCardDto());
}
