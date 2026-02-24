using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("enum_notification_template")]
public class NotificationTemplate :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public NotificationTemplate()
    {
        Translates = new HashSet<NotificationTemplateTranslate>();
    }
    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("key")]
    [StringLength(50)]
    public string Key { get; set; }

    [Column("subject")]
    [StringLength(100)]
    public string Subject { get; set; } = null!;

    [Column("message")]
    public string Message { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; private set; }
    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }
    #endregion

    #region Relationships
    [InverseProperty(nameof(NotificationTemplateTranslate.Owner))]
    public virtual ICollection<NotificationTemplateTranslate> Translates { get; set; } = new List<NotificationTemplateTranslate>();

    [ForeignKey("StateId")]
    public virtual State State { get; set; } = null!;
    #endregion

    #region Methods
    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;

    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;

    #endregion
}
