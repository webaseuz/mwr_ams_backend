using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class DeleteBatteryTypeCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
