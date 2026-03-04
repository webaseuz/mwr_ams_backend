using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class InstitutionTypeSelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string FinalYear { get; set; }
    public int OrganizationTypeId { get; set; }
    public string OrganizationName { get; set; }

}
