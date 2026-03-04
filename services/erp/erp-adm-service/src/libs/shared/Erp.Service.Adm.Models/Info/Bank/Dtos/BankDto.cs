using Erp.Core;
using Erp.Core.Models;

namespace Erp.Service.Adm.Models;
public class BankDto : ISysEntity<int>
{
    public int Id { get; set; }
    public int TableId { get; } = TableIdConst.ADM_INFO_BANK;
    public string Inn { get; set; }
    public string OrderCode { get; set; }
    public string BankCode { get; set; }
    public string Code { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public string Address { get; set; }
    public string Website { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public List<BankTranslateDto> Translates { get; set; } = new List<BankTranslateDto>();
}
