using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class CancelNotificationTemplateSettingCommand :
	IRequest<IHaveId<long>>
{
	public long Id { get; set; }
}
