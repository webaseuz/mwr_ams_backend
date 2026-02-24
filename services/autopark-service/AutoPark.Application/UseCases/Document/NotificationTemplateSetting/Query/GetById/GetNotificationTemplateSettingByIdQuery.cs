using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class GetNotificationTemplateSettingByIdQuery :
    IRequest<NotificationTemplateSettingDto>,
    IHaveIdProp<long>
{
    public long Id { get; set; }
}
