using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Nationalities;


public class CreateNationalityCommand :
    IRequest<IHaveId<int>>
{
    public string WbCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public List<NationalityTranslateCommand> Translates { get; set; }

}
