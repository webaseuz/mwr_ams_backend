using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("sys_user_refresh_token")]
[Index("IsDeleted", "TokenHash", "ExpireAt", Name = "indx_sys_user_refresh_token_isdel_hash_expire_at")]
[Index("IsDeleted", "UserId", "ExpireAt", Name = "indx_sys_user_refresh_token_isdel_user_id_expire_at")]
public partial class SysUserRefreshToken
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("expire_at", TypeName = "timestamp(6) without time zone")]
    public DateTime ExpireAt { get; set; }

    [Column("token_hash", TypeName = "character varying")]
    public string TokenHash { get; set; } = null!;

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

    [ForeignKey("UserId")]
    [InverseProperty("SysUserRefreshTokens")]
    public virtual SysUser User { get; set; } = null!;
}
