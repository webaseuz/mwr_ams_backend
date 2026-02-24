using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TireSizes;

public class CreateTireSizeCommand :
    IRequest<IHaveId<int>>
{
    public string OrderCode { get; set; }

    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Radius { get; set; }
}
