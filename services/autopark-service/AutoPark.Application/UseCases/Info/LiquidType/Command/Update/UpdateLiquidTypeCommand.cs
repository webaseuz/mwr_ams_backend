using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class UpdateLiquidTypeCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int StateId { get; set; }
    public List<LiquidTypeTranslateCommand> Translates { get; set; }
}
