using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Countries;

public class CreateCountryCommand :
    IRequest<IHaveId<int>>
{
    public string OrderCode { get; set; }
    public string Code { get; set; } = null!;
    public string TextCode { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;

    public List<CountryTranslateCommand> Translates { get; set; } = new();
}
