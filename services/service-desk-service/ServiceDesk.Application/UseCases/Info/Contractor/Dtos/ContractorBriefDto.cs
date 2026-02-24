namespace ServiceDesk.Application.UseCases.Info.Contractors;

public class ContractorBriefDto
{
	public long Id { get; set; }
	public string ShortName { get; set; } = null!;
	public string FullName { get; set; } = null!;
	public int CountryId { get; set; }
	public string CountryName { get; set; }
	public int RegionId { get; set; }
	public string RegionName { get; set; }
	public int DistrictId { get; set; }
	public string DistrictName { get; set; }
	public int? BankId { get; set; }
	public string Bank { get; set; }
	public string Address { get; set; }
	public string PhoneNumber { get; set; }
	public string ContactInfo { get; set; }
	public string Inn { get; set; } = null!;
	public string Accounter { get; set; }
	public string Director { get; set; }
	public string VatCode { get; set; }
	public int StateId { get; set; }
	public string StateName { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? ModifiedAt { get; set; }

}
