using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportColors;

public class UpdateTransportColorCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public List<TransportColorTranslateCommand> Translates { get; set; } = new();
}
