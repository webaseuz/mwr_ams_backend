using WEBASE.Models;

namespace WEBASE.LogSdk.BLL.Services;
public class ErrorScopeOption : SortFilterPageOptions
{
    public bool? IsFixed { get; set; }
    public bool IsDaily { get; set; } = false;
}