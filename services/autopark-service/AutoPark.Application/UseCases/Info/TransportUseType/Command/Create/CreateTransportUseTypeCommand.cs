using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class CreateTransportUseTypeCommand :
    IRequest<IHaveId<int>>
{
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public List<TransportUseTypeTranslateCommand> Translates { get; set; } = new();
}
