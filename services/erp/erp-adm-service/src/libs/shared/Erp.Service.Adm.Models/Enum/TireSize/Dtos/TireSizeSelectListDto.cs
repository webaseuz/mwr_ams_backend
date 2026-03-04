using WEBASE;

namespace Erp.Service.Adm.Models;

public class TireSizeSelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Diameter { get; set; }
}