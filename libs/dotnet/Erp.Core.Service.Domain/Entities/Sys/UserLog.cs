using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("sys_user_log")]
public class UserLog :
    BaseEntity<int>
{
    #region Properties

    [Column("action_name")]
    [StringLength(200)]
    public string ActionName { get; set; } = null!;

    [Column("user_name")]
    [StringLength(250)]
    public string UserName { get; set; } = null!;

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("ip_address")]
    [StringLength(200)]
    public string IpAddress { get; set; }

    [Column("user_agent")]
    [StringLength(2000)]
    public string UserAgent { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }
    #endregion

    #region Relationships
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }
    #endregion

}
