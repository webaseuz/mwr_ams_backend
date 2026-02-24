using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Roles;

public class RoleSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
