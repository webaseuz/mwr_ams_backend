namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class NotificationTemplateSettingBriefDto
{
	public long Id { get; set; }
	public string DocNumber { get; set; } = null!;
	public DateTime DocDate { get; set; }
	public int? BranchId { get; set; }
	public string BranchName { get; set; }
	public int NotificationTemplateId { get; set; }
	public string NotificationTemplateName { get; set; }
	public string NotificationTemplateMessage { get; set; }
	public DateTime CreatedAt { get; set; }
	public int StatusId { get; set; }
	public string StatusName { get; set; }

	#region Can
	public bool CanAccept { get; set; }
	public bool CanModify { get; set; }
	public bool CanDelete { get; set; }
	public bool CanCancel { get; set; }
	#endregion

}
