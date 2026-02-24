using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class CitizenshipSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
