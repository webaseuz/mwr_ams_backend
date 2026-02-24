using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.TransmissionBoxTypes;

public class TransmissionBoxTypeSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
