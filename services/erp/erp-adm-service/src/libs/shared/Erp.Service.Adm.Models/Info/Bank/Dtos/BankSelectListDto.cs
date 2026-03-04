using WEBASE;

namespace Erp.Service.Adm.Models;
public class BankSelectListDto : WbSelectListItem<int>
{
    public int Id { get; set; }
    public string Inn { get; set; }
    public string Code { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public string Address { get; set; }
    public string Website { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
}


