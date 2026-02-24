using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Citizenships;

public class UpdateCitizenshipCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string WbCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public List<CitizenshipTranslateCommand> Translates { get; set; }
}
