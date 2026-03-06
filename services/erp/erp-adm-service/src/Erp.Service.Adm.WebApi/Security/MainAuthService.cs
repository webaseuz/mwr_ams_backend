using Erp.Core;
using Erp.Core.Security;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Application;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.WebApi;

public class MainAuthService : IMainAuthService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IApplicationDbContext _context;
    public MainAuthService(IHttpContextAccessor httpContextAccessor, IApplicationDbContext context)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
        _context.SetAuthService(this);
    }

    #region IsAuthenticated
    protected bool? _isAuthenticated;
    public bool IsAuthenticated
    {
        get
        {
            if (_isAuthenticated == null)
            {
                // ====== BFF MODE (uncomment when switching back to BFF) ======
                // _isAuthenticated = _httpContextAccessor.HttpContext?.Request.Headers.ContainsKey(ApplicationHeaderConst.User);
                // ====== END BFF MODE ======

                // ====== DIRECT JWT MODE: IsAuthenticated is pre-loaded by IdentityLoader.LoadAsync() ======
                _isAuthenticated = false; // not authenticated if LoadAsync didn't set it via ResetUserName()
                // ====== END DIRECT JWT MODE ======
            }

            return _isAuthenticated ?? false;
        }
    }
    #endregion

    #region RequestedApp
    private int? _requestedAppId;
    public int? RequestedAppId
    {
        get
        {
            if (_requestedAppId == null)
            {
                var header = _httpContextAccessor.HttpContext?
                    .Request
                    .Headers[ApplicationHeaderConst.AppId]
                    .FirstOrDefault();

                if (int.TryParse(header, out var appId))
                    _requestedAppId = appId;
                else
                    _requestedAppId = null;
            }

            return _requestedAppId;
        }
    }
    #endregion

    #region App
    public int AppId => AppIdConst.ADM;
    #endregion

    #region UserName
    private string _userName;
    public string UserIdentityName => UserName;
    public string UserName
    {
        get
        {
            if (!IsAuthenticated)
            {
                return null;
            }

            if (IsAuthenticated && _user != null)
            {
                _userName = _user.UserName;
            }

            // ====== BFF MODE (uncomment when switching back to BFF) ======
            // if (_userName == null)
            //     _userName = _httpContextAccessor.HttpContext?.Request.Headers[ApplicationHeaderConst.User].FirstOrDefault();
            // ====== END BFF MODE ======

            // ====== DIRECT JWT MODE: _userName is pre-loaded by IdentityLoader.LoadAsync() via ResetUserName() ======
            // (no fallback needed — if not set by LoadAsync, IsAuthenticated returned false already)
            // ====== END DIRECT JWT MODE ======

            return _userName;
        }
    }
    #endregion

    #region User
    private IUserAuthModel _user;
    public IUserAuthModel User
    {
        get
        {
            if (IsAuthenticated && _user == null)
            {
                var userName = UserName;

                if (!string.IsNullOrEmpty(userName))
                {
                    var dbUser = _context.Users
                        .Include(u => u.Organization)
                        .Include(u => u.Person)
                        .Include(u => u.Language)
                        .Include(u => u.UserRoles.Where(r => r.StateId == WbStateIdConst.ACTIVE && !r.IsDeleted))
                            .ThenInclude(ur => ur.Role)
                                .ThenInclude(r => r.RolePermissions.Where(rp => !rp.IsDeleted))
                                    .ThenInclude(rp => rp.Permission)
                        .FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());

                    if (dbUser != null)
                    {
                        _user = new UserAuthModel
                        {
                            Id = dbUser.Id,
                            UserName = dbUser.UserName,
                            FullName = dbUser.Person?.FullName,
                            IsAdmin = dbUser.Id == 1,
                            LanguageId = dbUser.LanguageId,
                            LanguageCode = dbUser.Language?.Code,
                            Pinfl = dbUser.Person?.Pinfl,
                            PersonId = (int)dbUser.PersonId,
                            BranchId = dbUser.BranchId,
                            PositionId = dbUser.PositionId,
                            Organizations = dbUser.Organization != null
                                ? new List<IOrganizationAuthModel>
                                  {
                                      new OrganizationAuthModel
                                      {
                                          Id = dbUser.Organization.Id,
                                          FullName = dbUser.Organization.FullName,
                                          ShortName = dbUser.Organization.ShortName,
                                          RegionId = dbUser.Organization.RegionId,
                                          DistrictId = dbUser.Organization.DistrictId ?? 0,
                                          AppId = AppIdConst.ADM,
                                      }
                                  }
                                : new List<IOrganizationAuthModel>(),
                            Permissions = dbUser.UserRoles
                                .SelectMany(ur => ur.Role.RolePermissions
                                    .Select(rp => rp.Permission.Code))
                                .Distinct()
                                .ToList(),
                            SharedPermissions = new List<string>()
                        };

                        _user.ResolveModules();
                    }
                }
            }

            return _user;
        }
    }
    #endregion

    #region User IP & Agent
    private string _userIp;
    public string UserIp
    {
        get
        {
            if (_userIp == null)
            {
                _userIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                if (_httpContextAccessor.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
                {
                    _userIp = _userIp + ";" + _httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"];
                }
            }

            return _userIp;
        }
    }

    private string _userAgent;
    public string UserAgent
    {
        get
        {
            if (_userAgent == null && _httpContextAccessor.HttpContext.Request.Headers.ContainsKey("User-Agent"))
            {
                _userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
            }

            return _userAgent;
        }
    }
    #endregion

    #region UserId
    private long? _userId;
    public object UserIdentity => UserId;
    public object UserId
    {
        get
        {
            if (_userId != null)
                return _userId;

            if (IsAuthenticated && User != null)
                _userId = User.Id;

            return _userId;
        }
    }
    #endregion

    #region CurrentOrganizationId !
    private int? _currentOrganizationId;
    public int CurrentOrganizationId
    {
        get
        {
            if (_currentOrganizationId != null)
                return _currentOrganizationId.Value;

            if (IsAuthenticated)
                _currentOrganizationId = CurrentOrganization?.Id ?? 0;

            return _currentOrganizationId ?? 0;
        }
    }
    #endregion

    #region CurrentOrganization !
    private IOrganizationAuthModel _currentOrganization;
    public IOrganizationAuthModel CurrentOrganization
    {
        get
        {
            if (IsAuthenticated && _currentOrganization == null && User != null)
            {

                _currentOrganization = User.Organizations.FirstOrDefault();
                // vaqtinchalik user ni 1-orgini olingan,
                // agar userda 1 tadan ko'p org bo'lsa login payti so'rashi kk qaysi orgdan kirishini
                // va tanlab kirgan org bn ishlanishi kk
                //var organization = User.Organizations?.FirstOrDefault(a => a.AppId == AppIdConst.ADM);

                //if (organization != null)
                //{
                //    _currentOrganization = _context.Organizations
                //                                   .Include(a => a.Translates)
                //                                   .FirstOrDefault(a => a.Id == organization.Id)
                //                                   .MapToAuthModel();
                //}
            }

            return _currentOrganization;
        }
    }
    #endregion

    #region Module Permissions
    private HashSet<string> _modules;
    public HashSet<string> Modules
    {
        get
        {
            if (IsAuthenticated && _modules == null)
                _modules = User.Permissions.Concat(User.SharedPermissions).ToHashSet();
            return _modules;
        }
    }
    #endregion

    public bool HasPermission(params AdmPermissionCode[] permissionCodes)
    {
        return permissionCodes.Any(a => HasPermission(a.ToString()));
    }

    public bool HasPermission(params AutoparkPermissionCode[] permissionCodes)
    {
        return permissionCodes.Any(a => HasPermission(a.ToString()));
    }

    public void ResetUserName(string userName)
    {
        Clear();
        _isAuthenticated = true;
        _userName = userName;
    }

    public bool HasPermission(string moduleCode)
    {
        if (!IsAuthenticated)
        {
            return false;
        }

        return Modules.Contains(moduleCode);
    }

    public Task<bool> HasAnyPermissionAsync(string[] permissionCodes)
    {
        return Task.FromResult(Modules.Any(a => permissionCodes.Contains(a)));
    }

    protected virtual void Clear()
    {
        _isAuthenticated = null;

        _userName = null;
        _userId = null;

        _user = null;
        _modules = null;
        _currentOrganization = null;
        _currentOrganizationId = null;

        _userIp = null;
        _userAgent = null;
    }

    public void SetUser(IUserAuthModel user)
    {
        _user = user;
        _user?.ResolveModules();
    }
}
