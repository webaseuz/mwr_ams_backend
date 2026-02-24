namespace AutoPark.Application.UseCases.Branches;

public class BranchDto
{
    public int Id { get; set; }
    public string UniqueCode { get; set; }
    public int? ParentId { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int OrganizationId { get; set; }
    public int CountryId { get; set; }
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public string Address { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int StateId { get; private set; }
}
