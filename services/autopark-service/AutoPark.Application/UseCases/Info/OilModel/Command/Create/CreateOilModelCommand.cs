using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.OilModels;

public class CreateOilModelCommand :
    IRequest<IHaveId<int>>
{
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int OilTypeId { get; set; }
    public List<OilModelTranslateCommand> Translates { get; set; } = new();
}