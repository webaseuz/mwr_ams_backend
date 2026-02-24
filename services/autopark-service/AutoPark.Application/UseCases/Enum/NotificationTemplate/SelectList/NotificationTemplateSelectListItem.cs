using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.NotificationTemplates;

public class NotificationTemplateSelectListItem<TValue> : SelectListItem<TValue>
{
    public string Key { get; set; }
    public string Message { get; set; }
}
