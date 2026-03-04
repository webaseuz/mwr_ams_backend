using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class FixedMinimumValueSelectListDto : WbSelectListItem<int>
{
    public int MinimumValueTypeId { get; set; }
    public string MinimumValueType { get; set; }
    public decimal FixedAmount { get; set; }
}
