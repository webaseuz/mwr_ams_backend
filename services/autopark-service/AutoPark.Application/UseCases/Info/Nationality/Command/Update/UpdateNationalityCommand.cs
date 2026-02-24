using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Nationalities;

public class UpdateNationalityCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string WbCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public List<NationalityTranslateCommand> Translates { get; set; }
}
