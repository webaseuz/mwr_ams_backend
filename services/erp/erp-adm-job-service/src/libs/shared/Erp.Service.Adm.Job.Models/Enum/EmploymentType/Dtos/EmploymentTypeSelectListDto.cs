using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class EmploymentTypeSelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
}
