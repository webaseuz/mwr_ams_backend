using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class CitizenshipSelectListDto : WbSelectListItem<int>
{
    public string WbCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
}
