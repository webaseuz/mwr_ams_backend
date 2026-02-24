using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceDesk.Domain;
[Table("doc_notification_template_setting_role")]
public class NotificationTemplateSettingRole :
	IHaveIdProp<long>
{
	#region Properties
	[Key]
	[Column("id")]
	public long Id { get; set; }

	[Column("owner_id")]
	public long OwnerId { get; set; }
	[Column("role_id")]
	public int RoleId { get; set; }

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
	[ForeignKey(nameof(OwnerId))]
	public virtual NotificationTemplateSetting Owner { get; set; }
	[ForeignKey(nameof(RoleId))]
	public virtual Role Role { get; set; }
	#endregion

	#region Methods
	#endregion
}
