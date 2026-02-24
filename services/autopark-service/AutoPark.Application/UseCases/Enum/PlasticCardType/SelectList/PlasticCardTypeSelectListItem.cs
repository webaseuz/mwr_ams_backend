using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Enum.PlasticCardTypes;

public class PlasticCardTypeSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
