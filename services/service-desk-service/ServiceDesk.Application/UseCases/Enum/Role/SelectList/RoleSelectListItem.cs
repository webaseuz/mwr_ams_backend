using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Roles;

public class RoleSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
