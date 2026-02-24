using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Regions;

public class UpdateRegionCommand :
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
    public int CountryId { get; set; }
    public List<RegionTranslateCommand> Translates { get; set; } = new();
}
