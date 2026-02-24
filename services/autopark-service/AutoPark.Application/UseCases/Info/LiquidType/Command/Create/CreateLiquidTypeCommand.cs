using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class CreateLiquidTypeCommand :
    IRequest<IHaveId<int>>
{
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int StateId { get; set; }
    public List<LiquidTypeTranslateCommand> Translates { get; set; }
}
