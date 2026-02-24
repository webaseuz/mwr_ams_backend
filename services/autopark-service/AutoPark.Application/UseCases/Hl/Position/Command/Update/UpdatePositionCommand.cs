using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Positions;

public class UpdatePositionCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string OrderCode { get; set; }
    public List<PositionTranslateCommand> Translates { get; set; } = new();

}
