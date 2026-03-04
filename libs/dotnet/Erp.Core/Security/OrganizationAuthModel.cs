namespace Erp.Core.Security;

public interface IOrganizationAuthModel
{
    int Id { get; set; }
    string ShortName { get; set; }
    string FullName { get; set; }
    int RegionId { get; set; }
    string Region { get; set; }
    int DistrictId { get; set; }
    string District { get; set; }
    int? OrganizationTypeId { get; set; }
    int? InstitutionTypeId { get; set; }
    int? MusicOrganizationCategoryId { get; set; }
    int? ParentId { get; set; }
    string Parent { get; set; }
    string Inn { get; set; }
    public int AppId { get; set; }
    public int? OrganizationalStructureId { get; set; }
}
