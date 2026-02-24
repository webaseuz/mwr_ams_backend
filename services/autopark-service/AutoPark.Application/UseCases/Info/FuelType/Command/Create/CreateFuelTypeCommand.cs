using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.FuelTypes;

public class CreateFuelTypeCommand :
    IRequest<IHaveId<int>>
{
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;

    public List<FuelTypeTranslateCommand> Translates { get; set; }
}
