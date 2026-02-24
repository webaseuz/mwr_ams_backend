using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("hl_present_notification")]
public class PresentNotification :
    IHaveIdProp<long>
{
    public PresentNotification()
    {

    }
    #region Properties
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("owner_id")]
    public long OwnerId { get; set; }

    [Column("subject")]
    [StringLength(100)]
    public string Subject { get; set; }

    [Column("message")]
    public string Message { get; set; }

    [Column("notification_template_id")]
    public int NotificationTemplateId { get; set; }

    [Column("send_at")]
    public DateTime? SendAt { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }
    #endregion

    #region Relationships

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(NotificationTemplateId))]
    public virtual NotificationTemplate NotificationTemplate { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual Notification Notification { get; set; } = null!;
    #endregion

    #region Methods

    #endregion
}
