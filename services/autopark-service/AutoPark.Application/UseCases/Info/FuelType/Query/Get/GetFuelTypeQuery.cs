using MediatR;

namespace AutoPark.Application.UseCases.FuelTypes;

public class GetFuelTypeQuery :
    IRequest<FuelTypeDto>
{ }
