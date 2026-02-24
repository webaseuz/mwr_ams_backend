using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("sys_role")]
public partial class SysRole
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(20)]
    public string? OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

    [Column("is_admin")]
    public bool IsAdmin { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

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

    [ForeignKey("StateId")]
    [InverseProperty("SysRoles")]
    public virtual EnumState State { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<SysRolePermission> SysRolePermissions { get; set; } = new List<SysRolePermission>();

    [InverseProperty("Owner")]
    public virtual ICollection<SysRoleTranslate> SysRoleTranslates { get; set; } = new List<SysRoleTranslate>();

    [InverseProperty("Role")]
    public virtual ICollection<SysUserRole> SysUserRoles { get; set; } = new List<SysUserRole>();
}
