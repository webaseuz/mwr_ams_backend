namespace AutoPark.Application.UseCases.Notifications;

public class NotificationDto
{
    public long Id { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public int NotificationTemplateId { get; set; }
    public string NotificationTempleteName { get; set; } = null!;
    public DateTime? SentAt { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public bool IsRead { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; } = null!;
}