using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Persons;

public class PersonSelectListItem<TValue> : SelectListItem<TValue>
{
    public int? BranchId { get; set; }
}