using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("sys_permission")]
[Index("Code", Name = "uk_sys_permission_code", IsUnique = true)]
public partial class SysPermission
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string? OrderCode { get; set; }

    [Column("code")]
    [StringLength(100)]
    public string Code { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(300)]
    public string FullName { get; set; } = null!;

    [Column("sub_group_id")]
    public int SubGroupId { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("SysPermissions")]
    public virtual EnumState State { get; set; } = null!;

    [ForeignKey("SubGroupId")]
    [InverseProperty("SysPermissions")]
    public virtual SysPermissionSubGroup SubGroup { get; set; } = null!;

    [InverseProperty("Owner")]
    public virtual ICollection<SysPermissionTranslate> SysPermissionTranslates { get; set; } = new List<SysPermissionTranslate>();

    [InverseProperty("Permission")]
    public virtual ICollection<SysRolePermission> SysRolePermissions { get; set; } = new List<SysRolePermission>();
}
