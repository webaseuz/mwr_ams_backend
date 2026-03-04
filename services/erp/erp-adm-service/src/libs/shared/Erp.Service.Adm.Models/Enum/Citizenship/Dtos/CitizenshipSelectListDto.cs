using WEBASE;

namespace Erp.Service.Adm.Models;

public class CitizenshipSelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public bool IsCitizenship { get; set; }
}