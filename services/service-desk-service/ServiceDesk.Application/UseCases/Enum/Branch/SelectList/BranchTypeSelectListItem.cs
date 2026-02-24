using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Branches;

public class BranchTypeSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
