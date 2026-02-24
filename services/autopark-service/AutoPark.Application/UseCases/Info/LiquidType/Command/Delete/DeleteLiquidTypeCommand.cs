using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class DeleteLiquidTypeCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
