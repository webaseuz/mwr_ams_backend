using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.FuelTypes;

public class DeleteFuelTypeCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
