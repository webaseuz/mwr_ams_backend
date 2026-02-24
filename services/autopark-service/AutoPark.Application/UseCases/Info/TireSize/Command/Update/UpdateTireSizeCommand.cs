using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TireSizes;

public class UpdateTireSizeCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }

    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Radius { get; set; }
}
