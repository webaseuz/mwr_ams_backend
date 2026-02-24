using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Languages;

public class LanguageSelectListItem<TValue> : SelectListItem<TValue>
{
    public string FullName { get; set; }
}
