using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class UpdateBatteryTypeCommand :
     IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int StateId { get; set; }
    public List<BatteryTypeTranslateCommand> Translates { get; set; } = new();
}
