using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("doc_notification_template_setting")]
public class NotificationTemplateSetting :
    BaseEntity<long>
{
    public NotificationTemplateSetting()
    {
        Users = new HashSet<NotificationTemplateSettingUser>();
        Roles = new HashSet<NotificationTemplateSettingRole>();
        RestrictedUsers = new HashSet<NotificationTemplateSettingRestrictedUser>();
    }
    #region Properties

    [Column("doc_number")]
    [StringLength(50)]
    public string DocNumber { get; set; } = null!;

    [Column("doc_date")]
    public DateTime DocDate { get; set; }

    [Column("branch_id")]
    public int? BranchId { get; set; }
    [Column("notification_template_id")]
    public int NotificationTemplateId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

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
    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; }
    [ForeignKey(nameof(StatusId))]
    public virtual Status Status { get; set; }
    [ForeignKey(nameof(NotificationTemplateId))]
    public virtual NotificationTemplate NotificationTemplete { get; set; }
    [InverseProperty(nameof(NotificationTemplateSettingUser.Owner))]
    public virtual ICollection<NotificationTemplateSettingUser> Users { get; set; }
    [InverseProperty(nameof(NotificationTemplateSettingRole.Owner))]
    public virtual ICollection<NotificationTemplateSettingRole> Roles { get; set; }
    [InverseProperty(nameof(NotificationTemplateSettingRestrictedUser.Owner))]
    public virtual ICollection<NotificationTemplateSettingRestrictedUser> RestrictedUsers { get; set; }
    #endregion
}
