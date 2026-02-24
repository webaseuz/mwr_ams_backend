using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportBrands;

public class UpdateTransportBrandCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public List<TransportBrandTranslateCommand> Translates { get; set; } = new();
}
