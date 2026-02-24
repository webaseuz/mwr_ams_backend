using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Languages;

public class LanguageSelectListItem<TValue> : SelectListItem<TValue>
{
    public string FullName { get; set; }
}
