using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Branches;

public class BranchSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
