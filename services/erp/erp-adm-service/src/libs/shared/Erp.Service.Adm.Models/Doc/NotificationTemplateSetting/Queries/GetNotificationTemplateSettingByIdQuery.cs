using MediatR;

namespace Erp.Service.Adm.Models;

public class GetNotificationTemplateSettingByIdQuery : IRequest<NotificationTemplateSettingDto>
{
    public long Id { get; set; }
}
