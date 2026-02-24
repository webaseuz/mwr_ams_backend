using MediatR;

namespace AutoPark.Application.UseCases.FuelTypes;

public class GetFuelTypeByIdQuery :
    IRequest<FuelTypeDto>
{
    public int Id { get; set; }
}
