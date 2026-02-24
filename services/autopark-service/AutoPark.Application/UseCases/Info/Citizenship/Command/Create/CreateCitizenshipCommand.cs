using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Citizenships;

public class CreateCitizenshipCommand :
    IRequest<IHaveId<int>>
{
    public string WbCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public List<CitizenshipTranslateCommand> Translates { get; set; }
}
