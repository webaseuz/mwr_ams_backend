using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Persons;

public class PersonTypeSelectListItem<TValue> : SelectListItem<TValue>
{
    public int? BranchId { get; set; }
    public string PhoneNumber { get; set; }
}