using WEBASE;

namespace Erp.Service.Adm.Models;

public class ErrorScopeSortFilterPageOption : WbSortFilterPageOptions
{
    public bool? IsFixed { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
