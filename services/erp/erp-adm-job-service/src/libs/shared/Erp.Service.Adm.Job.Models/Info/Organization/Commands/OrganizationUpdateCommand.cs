using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Inn { get; set; }
    public string ShortName { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public int? InstitutionTypeId { get; set; }
    public int? ParentId { get; set; }
    public string PhoneNumber { get; set; }
    public int OrganizationalTypeId { get; set; }
    public int OrganizationalFormId { get; set; }
    public int StateId { get; set; }
    public string FullName { get; set; }
    public string Indexs { get; set; }
    public string Address { get; set; }
    public int? MfyId { get; set; }
    public bool IsParent { get; set; }
    public int OkedId { get; set; }
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public int OrganizationTypeId { get; set; }
    public int? MusicOrganizationCategoryId { get; set; }
    public string Manager { get; set; }
    public string Accountant { get; set; }
    public List<OrganizationAccountDto> Accounts { get; set; }
    public List<OrganizationTranslateCreateUpdateCommand> Translates { get; set; } = new List<OrganizationTranslateCreateUpdateCommand>();

}


