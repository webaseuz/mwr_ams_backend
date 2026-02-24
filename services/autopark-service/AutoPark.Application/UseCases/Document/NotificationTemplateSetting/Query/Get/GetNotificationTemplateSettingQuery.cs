using MediatR;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class GetNotificationTemplateSettingQuery :
    IRequest<NotificationTemplateSettingDto>
{
}
