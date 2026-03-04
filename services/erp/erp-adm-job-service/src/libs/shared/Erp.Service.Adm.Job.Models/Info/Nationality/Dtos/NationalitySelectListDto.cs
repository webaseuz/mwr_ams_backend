using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class NationalitySelectListDto : WbSelectListItem<int>
{
    public string Code { get; set; }
    public string TextCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
}
