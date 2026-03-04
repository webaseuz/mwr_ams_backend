using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("sys_user_refresh_token")]
public class UserRefreshToken :
    BaseEntity<Guid>
{
    #region Properties

    [Required]
    [Column("user_id")]
    public int UserId { get; set; }

    [Required]
    [Column("expire_at")]
    public DateTime ExpireAt { get; set; }

    [Required]
    [Column("token_hash")]
    public string TokenHash { get; set; }

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
    #endregion

}
