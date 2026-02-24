using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Domain;

[Table("sys_user")]
[Index("IsDeleted", "OrganizationId", "StateId", Name = "sys_user_index_isdel_orgid__staid")]
[Index("UserName", Name = "sys_user_index_user_name", IsUnique = true)]
public partial class SysUser
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_name")]
    [StringLength(250)]
    public string UserName { get; set; } = null!;

    [Column("user_identity")]
    [StringLength(250)]
    public string? UserIdentity { get; set; }

    [Column("password_hash")]
    [StringLength(250)]
    public string PasswordHash { get; set; } = null!;

    [Column("password_salt")]
    [StringLength(259)]
    public string PasswordSalt { get; set; } = null!;

    [Column("temporary_info")]
    [StringLength(500)]
    public string? TemporaryInfo { get; set; }

    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [Column("branch_id")]
    public int? BranchId { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [Column("position_id")]
    public int? PositionId { get; set; }

    [Column("person_id")]
    public long PersonId { get; set; }

    [Column("phone_number")]
    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    [Column("language_id")]
    public int? LanguageId { get; set; }

    [Column("last_access_time", TypeName = "timestamp without time zone")]
    public DateTime? LastAccessTime { get; set; }

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

    [InverseProperty("User")]
    public virtual ICollection<AccPresentSpareTurnover> AccPresentSpareTurnovers { get; set; } = new List<AccPresentSpareTurnover>();

    [InverseProperty("User")]
    public virtual ICollection<AccSpareTurnover> AccSpareTurnovers { get; set; } = new List<AccSpareTurnover>();

    [ForeignKey("BranchId")]
    [InverseProperty("SysUsers")]
    public virtual HlBranch? Branch { get; set; }

    [InverseProperty("FromUser")]
    public virtual ICollection<DocSpareMovement> DocSpareMovementFromUsers { get; set; } = new List<DocSpareMovement>();

    [InverseProperty("ToUser")]
    public virtual ICollection<DocSpareMovement> DocSpareMovementToUsers { get; set; } = new List<DocSpareMovement>();

    [ForeignKey("LanguageId")]
    [InverseProperty("SysUsers")]
    public virtual EnumLanguage? Language { get; set; }

    [ForeignKey("OrganizationId")]
    [InverseProperty("SysUsers")]
    public virtual InfoOrganization Organization { get; set; } = null!;

    [ForeignKey("PersonId")]
    [InverseProperty("SysUsers")]
    public virtual HlPerson Person { get; set; } = null!;

    [ForeignKey("PositionId")]
    [InverseProperty("SysUsers")]
    public virtual HlPosition? Position { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("SysUsers")]
    public virtual EnumState State { get; set; } = null!;

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<SysRolePermission> SysRolePermissions { get; set; } = new List<SysRolePermission>();

    [InverseProperty("User")]
    public virtual ICollection<SysUserRefreshToken> SysUserRefreshTokens { get; set; } = new List<SysUserRefreshToken>();

    [InverseProperty("User")]
    public virtual ICollection<SysUserRole> SysUserRoles { get; set; } = new List<SysUserRole>();

    [InverseProperty("User")]
    public virtual ICollection<SysUserToken> SysUserTokens { get; set; } = new List<SysUserToken>();
}
