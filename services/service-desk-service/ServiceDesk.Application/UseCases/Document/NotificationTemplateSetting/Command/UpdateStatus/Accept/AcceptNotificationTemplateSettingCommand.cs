using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class AcceptNotificationTemplateSettingCommand :
	IRequest<IHaveId<long>>
{
	public long Id { get; set; }
}
