namespace Erp.Service.Adm.Job.Models;
public class OrganizationBriefDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string Inn { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public int? EduTypeId { get; set; }
    public int? InstitutionTypeId { get; set; }
    public string InstitutionType { get; set; }
    public int? ParentId { get; set; }
    public string Parent { get; set; }
    public string PhoneNumber { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public string Indexs { get; set; }
    public string Address { get; set; }
    public bool IsParent { get; set; }
    public int? MfyId { get; set; }
    public string Mfy { get; set; }
    public int? OkedId { get; set; }
    public string Oked { get; set; }
    public int RegionId { get; set; }
    public string Region { get; set; }
    public int DistrictId { get; set; }
    public string District { get; set; }
    public int? OrganizationTypeId { get; set; }
    public string OrganizationType { get; set; }

}
