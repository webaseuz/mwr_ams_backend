using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationAccountSelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public int StateId { get; set; }

}
