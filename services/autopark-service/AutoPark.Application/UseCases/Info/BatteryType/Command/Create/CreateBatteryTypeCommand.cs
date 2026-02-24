using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class CreateBatteryTypeCommand :
    IRequest<IHaveId<int>>
{
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public List<BatteryTypeTranslateCommand> Translates { get; set; } = new();
}
