using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class DeleteNotificationTemplateSettingCommand :
    IRequest<SuccessResult<bool>>,
    IHaveIdProp<long>
{
    public long Id { get; set; }
}
