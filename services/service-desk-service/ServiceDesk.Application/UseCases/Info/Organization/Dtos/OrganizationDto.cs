using ServiceDesk.Application.UseCases.Countries;
using ServiceDesk.Application.UseCases.Districts;

namespace ServiceDesk.Application.UseCases.Organizations;

public class OrganizationDto
{
	public int Id { get; set; }
	public string OrderCode { get; set; }
	public string ShortName { get; set; } = null!;
	public string FullName { get; set; } = null!;
	public string Inn { get; set; }
	public int? ParentId { get; set; }
	public OrganizationDto Parent { get; set; }
	public int CountryId { get; set; }
	public CountryDto Country { get; set; }
	public int RegionId { get; set; }
	public string Region { get; set; }
	public int? DistrictId { get; set; }
	public DistrictDto District { get; set; }
	public string Address { get; set; }
	public string PhoneNumber { get; set; }
	public string Director { get; set; }
	public string VatCode { get; set; }
	public string ZipCode { get; set; }
	public string Latitude { get; set; }
	public string Longitude { get; set; }
	public int StateId { get; set; }
	public string StateName { get; set; }
	public List<OrganizationTranslateDto> Translates { get; set; } = new();
}
