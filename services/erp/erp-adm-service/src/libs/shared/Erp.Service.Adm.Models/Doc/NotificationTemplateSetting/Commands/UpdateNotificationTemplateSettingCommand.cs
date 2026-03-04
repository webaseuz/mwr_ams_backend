using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class UpdateNotificationTemplateSettingCommand : IRequest<WbHaveId<long>>
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
