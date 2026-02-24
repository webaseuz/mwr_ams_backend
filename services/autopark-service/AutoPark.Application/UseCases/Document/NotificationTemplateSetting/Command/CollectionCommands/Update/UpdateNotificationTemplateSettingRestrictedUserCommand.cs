using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class UpdateNotificationTemplateSettingRestrictedUserCommand :
    IHaveIdProp<long>
{
    public long Id { get; set; }
    public int UserId { get; set; }
}
