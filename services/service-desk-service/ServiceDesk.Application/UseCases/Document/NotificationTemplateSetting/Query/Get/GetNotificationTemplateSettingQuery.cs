using MediatR;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class GetNotificationTemplateSettingQuery :
	IRequest<NotificationTemplateSettingDto>
{
}
