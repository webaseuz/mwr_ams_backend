using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Enum.CodeFromTypes;

public class CodeFormTypeSelectListItem<TValue> : SelectList<TValue>
{
    public string FullName { get; set; }
}
