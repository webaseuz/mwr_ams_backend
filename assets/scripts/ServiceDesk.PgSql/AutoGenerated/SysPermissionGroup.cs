using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("sys_permission_group")]
public partial class SysPermissionGroup
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string? OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(300)]
    public string FullName { get; set; } = null!;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Owner")]
    public virtual ICollection<SysPermissionGroupTranslate> SysPermissionGroupTranslates { get; set; } = new List<SysPermissionGroupTranslate>();

    [InverseProperty("Group")]
    public virtual ICollection<SysPermissionSubGroup> SysPermissionSubGroups { get; set; } = new List<SysPermissionSubGroup>();
}
