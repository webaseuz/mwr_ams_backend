using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("sys_role_permission")]
public partial class SysRolePermission
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; }

    [Column("permission_id")]
    public int PermissionId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_by")]
    public int CreatedBy { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SysRolePermissions")]
    public virtual SysUser CreatedByNavigation { get; set; } = null!;

    [ForeignKey("PermissionId")]
    [InverseProperty("SysRolePermissions")]
    public virtual SysPermission Permission { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("SysRolePermissions")]
    public virtual SysRole Role { get; set; } = null!;
}
