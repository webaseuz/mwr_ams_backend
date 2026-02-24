using AutoPark.Domain.Constants;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("doc_notification_template_setting")]
public class NotificationTemplateSetting :
    IHaveIdProp<long>
{
    public NotificationTemplateSetting()
    {
        Users = new HashSet<NotificationTemplateSettingUser>();
        Roles = new HashSet<NotificationTemplateSettingRole>();
        RestrictedUsers = new HashSet<NotificationTemplateSettingRestrictedUser>();
    }
    #region Properties
    [Key]
    [Column("id")]
    public long Id { get; set; }

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
    public int StatusId { get; private set; }

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

    #region Methods
    public void Create()
        => UpdateStatus(StatusIdConst.CREATED);


    public void Update()
        => UpdateStatus(StatusIdConst.MODIFIED);


    public void Delete()
        => UpdateStatus(StatusIdConst.DELETED);


    public void Accept()
        => UpdateStatus(StatusIdConst.ACCEPTED);


    public void Cancel()
        => UpdateStatus(StatusIdConst.CANCELLED);

    public void UpdateStatus(int statusId)
    {
        if (!StatusIdConst.CanNotificationTemplateSettingStatus(StatusId, statusId))
            throw ClientLogicalExceptionHelper.NotAllowedStatus();

        StatusId = statusId;
    }
    #endregion
}
