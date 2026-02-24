using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Districts;

public class CreateDistrictCommand :
    IRequest<IHaveId<int>>
{
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string Soato { get; set; }
    public string RoamingCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int RegionId { get; set; }
    public List<DistrictTranslateCommand> Translates { get; set; } = new();

}
