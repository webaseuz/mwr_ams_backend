using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Users;

public class UserSelectListItem<TValue> : SelectListItem<TValue>
{
    public string FullName { get; set; }
}
