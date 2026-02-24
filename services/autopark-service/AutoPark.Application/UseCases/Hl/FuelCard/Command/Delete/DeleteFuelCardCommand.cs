using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.FuelCards;

public class DeleteFuelCardCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
