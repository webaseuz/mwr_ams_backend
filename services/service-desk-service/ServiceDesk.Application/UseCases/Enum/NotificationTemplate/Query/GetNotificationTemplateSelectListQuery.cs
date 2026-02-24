using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.NotificationTemplates;

public class GetNotificationTemplateSelectListQuery :
	IRequest<SelectList<long>>
{
}
