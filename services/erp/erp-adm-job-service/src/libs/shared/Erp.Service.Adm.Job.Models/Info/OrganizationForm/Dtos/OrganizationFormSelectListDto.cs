using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationFormSelectListDto : WbSelectListItem<int>
{
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string State { get; set; }
}
