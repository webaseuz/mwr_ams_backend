using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class UnitOfMeasureSelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }

}
