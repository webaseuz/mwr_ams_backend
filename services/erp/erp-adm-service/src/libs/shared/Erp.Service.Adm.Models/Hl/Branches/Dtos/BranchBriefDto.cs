namespace Erp.Service.Adm.Models;

public class BranchBriefDto
{
    public int Id { get; set; }
    public string UniqueCode { get; set; } = null!;
    public int? ParentId { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int OrganizationId { get; set; }
    public int CountryId { get; set; }
    public int RegionId { get; set; }
    public string RegionName { get; set; } = null!;
    public int DistrictId { get; set; }
    public string DistrictName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Latitude { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    public int StateId { get; set; }
    public string StateName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}
