using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Permissons;

public class PermissionSelectListItem<TValue> : SelectListItem<TValue>
{
    public string FullName { get; set; }
}
