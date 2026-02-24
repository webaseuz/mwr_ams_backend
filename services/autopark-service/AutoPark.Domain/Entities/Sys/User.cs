using Bms.Core.Domain;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Domain;

[Table("sys_user")]
public class User :
    IHaveIdProp<int>,
    IHaveSoftStateId
{
    public User()
    {
        UserRoles = new HashSet<UserRole>();
        Tokens = new HashSet<UserToken>();
        RefreshTokens = new HashSet<UserRefreshToken>();
        Logs = new HashSet<UserLog>();
    }

    #region Properties
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_name")]
    [StringLength(250)]
    public string UserName { get; set; }

    [Column("password_hash")]
    [StringLength(250)]
    public string PasswordHash { get; private set; }

    [Column("password_salt")]
    [StringLength(259)]
    public string PasswordSalt { get; private set; }

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
    public DateTime? LastAccessTime { get; private set; }

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
    public virtual ICollection<UserToken> Tokens { get; private set; }

    [InverseProperty(nameof(UserRefreshToken.User))]
    public virtual ICollection<UserRefreshToken> RefreshTokens { get; private set; }

    [InverseProperty(nameof(UserLog.User))]
    public virtual ICollection<UserLog> Logs { get; /*set; */}

    #endregion

    #region Methods
    public void MarkAsActive()
        => StateId = StateIdConst.ACTIVE;

    public void MarkAsPassive()
        => StateId = StateIdConst.PASSIVE;

    /// <summary>
    /// When user related actions happen log will be inserted
    /// </summary>
    /// <param name="action"></param>
    /// <param name="userIp"></param>
    /// <param name="userAgent"></param>
    public void AddLog(UserLogAction action,
                       string userIp,
                       string userAgent)
    {
        Logs.Add(new UserLog
        {
            UserId = Id,
            UserName = UserName,
            UserAgent = userAgent,
            ActionName = action.ToString(),
            IpAddress = userIp
        });
    }

    /// <summary>
    /// When user logged in token is created 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="expireAt"></param>
    /// <param name="isRefreshToken"></param>
    /// <param name="tokenHash"></param>
    public void AddToken(string userIdentity,
                         string tokenHash,
                         DateTime expireAt)
    {
        Tokens.Add(new UserToken
        {
            UserId = Id,
            UserIdentity = userIdentity,
            ExpireAt = expireAt,
            TokenHash = tokenHash,
            CreatedAt = DateTime.Now
        });
    }

    /// <summary>
    /// When user logged in refresh token is created 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="expireAt"></param>
    /// <param name="isRefreshToken"></param>
    /// <param name="tokenHash"></param>
    public void AddRefreshToken(string tokenHash,
                                DateTime expireAt)
    {
        RefreshTokens.Add(new UserRefreshToken
        {
            UserId = Id,
            ExpireAt = expireAt,
            TokenHash = tokenHash,
            CreatedAt = DateTime.Now
        });
    }

    /// <summary>
    /// When User Logged In this method will be used in AccountService
    /// </summary>
    /// <param name="date"></param>
    public void SetLastAccessTime(DateTime date)
        => LastAccessTime = date;

    /// <summary>
    /// Set Password from extern
    /// </summary>
    /// <param name="passwordHash"></param>
    /// <param name="passwordSalt"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void SetPassword(string passwordHash, string passwordSalt)
    {
        if (string.IsNullOrEmpty(passwordHash))
            throw ClientValidationExceptionHelper.NotNullPropert("password 1 part is empty");

        if (string.IsNullOrEmpty(passwordSalt))
            throw ClientValidationExceptionHelper.NotNullPropert("password 2 part is empty");

        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    public void ChangePhoneNumber(string phoneNumber)
    {
        if (phoneNumber.NullOrEmpty())
            throw ClientValidationExceptionHelper.NotNullPropert("Phone number is empty");

        SetPhoneNumber(phoneNumber);
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        if (!phoneNumber.NullOrEmpty())
            PhoneNumber = phoneNumber;
    }
    #endregion
}