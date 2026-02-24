using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Districts;

public class UpdateDistrictCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string Soato { get; set; }
    public string RoamingCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int RegionId { get; set; }

    public List<DistrictTranslateCommand> Translates { get; set; } = new();
}