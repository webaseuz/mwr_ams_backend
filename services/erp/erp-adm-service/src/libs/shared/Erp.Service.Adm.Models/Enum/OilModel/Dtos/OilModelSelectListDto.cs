using WEBASE;

namespace Erp.Service.Adm.Models;

public class OilModelSelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public string FullName { get; set; }
}