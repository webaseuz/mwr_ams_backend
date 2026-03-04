namespace Erp.Service.Adm.Models;

public class ContractorBriefDto
{
    public long Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int CountryId { get; set; }
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public int? BankId { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ContactInfo { get; set; }
    public string Inn { get; set; }
    public string? Accounter { get; set; }
    public string? Director { get; set; }
    public string? VatCode { get; set; }
    public int StateId { get; set; }
    public string? StateName { get; set; }
}
