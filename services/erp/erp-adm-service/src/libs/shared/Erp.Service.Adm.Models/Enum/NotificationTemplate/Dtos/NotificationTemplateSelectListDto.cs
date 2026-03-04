using WEBASE;

namespace Erp.Service.Adm.Models;

public class NotificationTemplateSelectListDto : WbSelectListItem<long>
{
    public long Id { get; set; }
    public string Key { get; set; }
    public string Message { get; set; }
}