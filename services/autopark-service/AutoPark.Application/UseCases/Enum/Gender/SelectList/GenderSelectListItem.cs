using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Enum.Genders;

public class GenderSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
