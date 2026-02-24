using ServiceDesk.Application.UseCases.Countries;

namespace ServiceDesk.Application.UseCases.Regions;

public class RegionDto
{
	public int Id { get; set; }
	public string OrderCode { get; set; }
	public string Code { get; set; }
	public string Soato { get; set; }
	public string RoamingCode { get; set; }
	public string ShortName { get; set; } = null!;
	public string FullName { get; set; } = null!;
	public int CountryId { get; set; }
	public CountryDto Country { get; set; }
	public int StateId { get; set; }
	public string StateName { get; set; }
	public List<RegionTranslateDto> Translates { get; set; } = new();
}
