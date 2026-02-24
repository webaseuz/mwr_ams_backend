namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class NotificationTemplateSettingDto
{
    public long Id { get; set; }
    public string DocNumber { get; set; } = null!;
    public DateTime DocDate { get; set; }
    public int? BranchId { get; set; }
    public string BranchName { get; set; }
    public int NotificationTemplateId { get; set; }
    public string NotificationTemplateName { get; set; }
    public string NotificationTemplateMessage { get; set; }
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public bool CanCreateForAllBranch { get; set; }
    public List<NotificationTemplateSettingUserDto> Users { get; set; } = new();
    public List<NotificationTemplateSettingRoleDto> Roles { get; set; } = new();
    public List<NotificationTemplateSettingRestrictedUserDto> RestrictedUsers { get; set; } = new();
}
