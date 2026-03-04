using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OkedSelectListDto : WbSelectListItem<int>
{
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int IsGroup { get; set; }
    public int? ParentId { get; set; }
    public string OrganizationName { get; set; }
}
