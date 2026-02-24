using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.TireModels;

public class CreateTireModelCommand :
    IRequest<IHaveId<int>>
{
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public List<TireModelTranslateCommand> Translates { get; set; } = new();
}