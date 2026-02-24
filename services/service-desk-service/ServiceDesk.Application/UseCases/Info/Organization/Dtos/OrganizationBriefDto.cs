namespace ServiceDesk.Application.UseCases.Organizations;

public class OrganizationBriefDto
{
	public int Id { get; set; }
	public string OrderCode { get; set; }
	public string ShortName { get; set; } = null!;
	public string FullName { get; set; } = null!;
	public string Inn { get; set; }
	public int? ParentId { get; set; }
	public string ParentName { get; set; }
	public int CountryId { get; set; }
	public string CountryName { get; set; }
	public int RegionId { get; set; }
	public string RegionName { get; set; }
	public int? DistrictId { get; set; }
	public string DistrictName { get; set; }
	public string Address { get; set; }
	public string PhoneNumber { get; set; }
	public string Director { get; set; }
	public string VatCode { get; set; }
	public string ZipCode { get; set; }
	public int StateId { get; set; }
	public string StateName { get; set; }
}
