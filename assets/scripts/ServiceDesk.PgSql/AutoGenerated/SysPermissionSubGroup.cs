using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("sys_permission_sub_group")]
[Index("Code", Name = "sys_permission_sub_group_unique_index_code", IsUnique = true)]
public partial class SysPermissionSubGroup
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(100)]
    public string Code { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(300)]
    public string FullName { get; set; } = null!;

    [Column("group_id")]
    public int GroupId { get; set; }

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

    [ForeignKey("GroupId")]
    [InverseProperty("SysPermissionSubGroups")]
    public virtual SysPermissionGroup Group { get; set; } = null!;

    [InverseProperty("Owner")]
    public virtual ICollection<SysPermissionSubGroupTranslate> SysPermissionSubGroupTranslates { get; set; } = new List<SysPermissionSubGroupTranslate>();

    [InverseProperty("SubGroup")]
    public virtual ICollection<SysPermission> SysPermissions { get; set; } = new List<SysPermission>();
}
