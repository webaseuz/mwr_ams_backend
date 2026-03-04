using Erp.Core;
using Erp.Core.Security;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Job.Application;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Adm.Job.WebApi;

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

    protected bool? _isAuthenticated;
    private long? _userId;
    private string _userName;
    private string _userIp;
    private string _userAgent;
    private HashSet<string> _modules;
    private int? _currentOrganizationId;

    public bool IsAuthenticated
    {
        get
        {
            if (_isAuthenticated == null)
                _isAuthenticated = _httpContextAccessor.HttpContext?.Request.Headers.ContainsKey("X-User");

            return _isAuthenticated ?? false;
        }
    }

    public int AppId => AppIdConst.ADM;

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

    private IUserAuthModel _user;
    public IUserAuthModel User
    {
        get
        {
            if (IsAuthenticated && _user == null)
            {
                var userName = _httpContextAccessor.HttpContext?.Request.Headers["X-User"].FirstOrDefault();

                if (!string.IsNullOrEmpty(userName))
                {
                    _user = _context.Users.MapToAuthModel(RequestedAppId).FirstOrDefault(a => a.UserName.ToLower() == userName.ToLower());
                }

                _user?.ResolveModules();
            }

            return _user;
        }
    }

    public string UserIdentityName => UserName;

    public object UserIdentity => UserId;

    public string UserName
    {
        get
        {
            if (!IsAuthenticated)
            {
                return null;
            }

            if (IsAuthenticated && User != null)
            {
                _userName = User.UserName;
            }

            if (_userName == null)
            {
                _userName = _httpContextAccessor.HttpContext?.Request.Headers["X-User"].FirstOrDefault();
            }

            return _userName;
        }
    }

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
                //var organization = User.Organizations?.FirstOrDefault(a => a.AppId == AppIdConst.ADM.JOB);

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

    public HashSet<string> Modules
    {
        get
        {
            if (IsAuthenticated && _modules == null)
                _modules = User.Permissions.Concat(User.SharedPermissions).ToHashSet();
            return _modules;
        }
    }

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

    public bool HasPermission(params AdmPermissionCode[] permissionCodes)
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
