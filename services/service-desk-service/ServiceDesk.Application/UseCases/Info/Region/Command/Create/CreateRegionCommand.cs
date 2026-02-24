using Bms.WEBASE.Models;
using MediatR;
namespace ServiceDesk.Application.UseCases.Regions;

public class CreateRegionCommand :
	IRequest<IHaveId<int>>
{
	public string OrderCode { get; set; }
	public string Code { get; set; }
	public string Soato { get; set; }
	public string RoamingCode { get; set; }
	public string ShortName { get; set; } = null!;
	public string FullName { get; set; } = null!;
	public int CountryId { get; set; }
	public List<RegionTranslateCommand> Translates { get; set; } = new();
}