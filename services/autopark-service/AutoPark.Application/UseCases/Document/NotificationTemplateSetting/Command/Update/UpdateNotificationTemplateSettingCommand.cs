using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class UpdateNotificationTemplateSettingCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public string DocNumber { get; set; } = null!;
    public DateTime DocDate { get; set; }
    public int? BranchId { get; set; }
    public int NotificationTemplateId { get; set; }
    public List<UpdateNotificationTemplateSettingUserCommand> Users { get; set; } = new List<UpdateNotificationTemplateSettingUserCommand>();
    public List<UpdateNotificationTemplateSettingRoleCommand> Roles { get; set; } = new List<UpdateNotificationTemplateSettingRoleCommand>();
    public List<UpdateNotificationTemplateSettingRestrictedUserCommand> RestrictedUsers { get; set; } = new List<UpdateNotificationTemplateSettingRestrictedUserCommand>();
}
