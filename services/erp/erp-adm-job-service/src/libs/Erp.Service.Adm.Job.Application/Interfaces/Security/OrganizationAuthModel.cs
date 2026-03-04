using Erp.Core.Security;

namespace Erp.Service.Adm.Job.Application;

public class OrganizationAuthModel : IOrganizationAuthModel
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public int? ParentId { get; set; }
    public string Parent { get; set; }
    public string Inn { get; set; }
    public int AppId { get; set; }
    public int? OrganizationalStructureId { get; set; }
    public int? OrganizationTypeId { get; set; }
    public int? InstitutionTypeId { get; set; }
    public int? MusicOrganizationCategoryId { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
}
