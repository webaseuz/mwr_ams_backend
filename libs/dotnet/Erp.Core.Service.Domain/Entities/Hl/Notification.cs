using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("hl_notification")]
public class Notification :
    BaseEntity<long>
{
    public Notification()
    {

    }
    #region Properties
    [Column("subject")]
    [StringLength(50)]
    public string Subject { get; set; }

    [Column("message")]
    public string Message { get; set; }

    [Column("notification_template_id")]
    public int NotificationTemplateId { get; set; }

    [Column("sent_at")]
    public DateTime? SentAt { get; set; }
    [Column("read_at", TypeName = "timestamp without time zone")]
    public DateTime? ReadAt { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("is_read")]
    public bool IsRead { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? LastModifiedAt { get; set; }

    [Column("modified_by")]
    public int? LastModifiedBy { get; set; }
    #endregion

    #region Relationships

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(NotificationTemplateId))]
    public virtual NotificationTemplate NotificationTemplate { get; set; } = null!;

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;
    #endregion

}
