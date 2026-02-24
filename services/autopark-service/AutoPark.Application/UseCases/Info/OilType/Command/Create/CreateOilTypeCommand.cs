using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.OilTypes;

public class CreateOilTypeCommand :
    IRequest<IHaveId<int>>
{
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public List<OilTypeTranslateCommand> Translates { get; set; } = new();
}