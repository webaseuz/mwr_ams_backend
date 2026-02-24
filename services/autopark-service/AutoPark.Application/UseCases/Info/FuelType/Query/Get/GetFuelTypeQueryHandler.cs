using MediatR;

namespace AutoPark.Application.UseCases.FuelTypes;

public class GetFuelTypeQueryHandler :
    IRequestHandler<GetFuelTypeQuery, FuelTypeDto>
{
    public Task<FuelTypeDto> Handle(
        GetFuelTypeQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new FuelTypeDto());
}
