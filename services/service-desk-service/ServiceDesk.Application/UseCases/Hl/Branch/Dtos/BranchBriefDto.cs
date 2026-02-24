namespace ServiceDesk.Application.UseCases.Branches;

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
    public string RegionName { get; set; }
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }
    public string Address { get; set; } = null!;
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int StateId { get; private set; }
    public string StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
