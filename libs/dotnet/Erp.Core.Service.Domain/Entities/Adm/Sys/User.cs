using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Core.Service.Domain;

[Table("sys_user", Schema = "adm")]
public class User :
    BaseEntity<int>
{
    public User()
    {
        UserRoles = new HashSet<UserRole>();
        Tokens = new HashSet<UserToken>();
        RefreshTokens = new HashSet<UserRefreshToken>();
        Logs = new HashSet<UserLog>();
    }

    #region Properties

    [Column("user_name")]
    [StringLength(250)]
    public string UserName { get; set; }

    [Column("password_hash")]
    [StringLength(250)]
    public string PasswordHash { get; set; }

    [Column("password_salt")]
    [StringLength(259)]
    public string PasswordSalt { get; set; }

    [Column("temporary_info")]
    [StringLength(500)]
    public string TemporaryInfo { get; set; }

    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [Column("person_id")]
    public long PersonId { get; set; }

    [Column("branch_id")]
    public int? BranchId { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [Column("position_id")]
    public int? PositionId { get; set; }

    [Column("phone_number")]
    [StringLength(50)]
    public string PhoneNumber { get; set; }

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
    public DateTime? LastModifiedAt { get; set; }

    [Column("modified_by")]
    public int? LastModifiedBy { get; set; }

    #endregion

    #region Relationships

    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; }

    [ForeignKey(nameof(OrganizationId))]
    public virtual Organization Organization { get; set; }

    [ForeignKey(nameof(PersonId))]
    public virtual Person Person { get; set; }
    [ForeignKey(nameof(DepartmentId))]
    public virtual Department Department { get; set; }
    [ForeignKey(nameof(PositionId))]
    public virtual Position Position { get; set; }

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; }

    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; }

    [InverseProperty(nameof(UserRole.User))]
    public virtual ICollection<UserRole> UserRoles { get; set; }

    [InverseProperty(nameof(UserToken.User))]
    public virtual ICollection<UserToken> Tokens { get; set; }

    [InverseProperty(nameof(UserRefreshToken.User))]
    public virtual ICollection<UserRefreshToken> RefreshTokens { get; set; }

    [InverseProperty(nameof(UserLog.User))]
    public virtual ICollection<UserLog> Logs { get; /*set; */}

    #endregion

}
