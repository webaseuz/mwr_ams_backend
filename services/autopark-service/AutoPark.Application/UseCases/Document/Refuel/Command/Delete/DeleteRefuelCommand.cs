using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Refuels;

public class DeleteRefuelCommand :
    IRequest<SuccessResult<bool>>
{
    public long Id { get; set; }
}
