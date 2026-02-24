using ServiceDesk.Domain.Entities.Sys;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDesk.Domain;

[Table("sys_role")]
public class Role :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public Role()
    {
        Translates = new HashSet<RoleTranslate>();
        RolePermissions = new HashSet<RolePermission>();
    }
    #region
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(20)]
    public string OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("is_admin")]
    public bool IsAdmin { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

    [Column("state_id")]
    public int StateId { get; set; }

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

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; private set; } = null!;

    [InverseProperty(nameof(RoleTranslate.Owner))]
    public virtual ICollection<RoleTranslate> Translates { get; set; } = new List<RoleTranslate>();

    [InverseProperty(nameof(RolePermission.Role))]
    public virtual ICollection<RolePermission> RolePermissions { get; set; }
    #endregion

    #region Methods
    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;
    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;

    #endregion
}
