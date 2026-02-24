using ServiceDesk.Application;
using ServiceDesk.Application.Security;
using Bms.WEBASE.Security;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ServiceDesk.Infrastructure.Security;

public class AppAuthService :
    BaseAuthService,
    IAsyncAppAuthService
{
    private readonly ITokenProvider _tokenProvider;
    private readonly IReadEfCoreContext _context;
    public AppAuthService(
        ITokenProvider tokenProvider,
        IAsyncAppTokenService tokenService,
        IReadEfCoreContext context) :
        base(tokenProvider, tokenService)
    {
        _tokenProvider = tokenProvider;
        _context = context;
    }

    public override string AuthenticationType
        => nameof(AuthenticationTypeConst.RERERENCE);

    public async Task<OrganizationAuthModel> GetOrganizationAsync()
    {
        var user = await GetUserAsync();

        if (user == null)
            return null;

        var organization = await _context.Organizations
            .MapToOrganizationModel()
            .FirstOrDefaultAsync(o => o.Id == user.OrganizationId);

        return organization;
    }

    private UserAuthModel _user;

    public async Task<UserAuthModel> GetUserAsync()
    {
        var isAuthenticated =  await IsAuthenticatedAsync();

        if (isAuthenticated && _user == null)
        {
            var useridentity = await GetUserIdentityAsync();

            _user = await _context.Users
                .MapToAuthModel()
                .FirstOrDefaultAsync(u => u.UserName == useridentity);

            _user?.ResolvePermissions();
        }

        return _user;
    }
    private int? _userId = null;
    public override async Task<object> GetUserIdAsync()
    {
        var isAuthenticated = await IsAuthenticatedAsync();

        if (isAuthenticated && _userId == null)
        {
            var useridentity = await GetUserIdentityAsync();

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == useridentity);

            _userId = user.Id;
        }

        return _userId;
    }


    private string _userIdentity = null;
    public override async Task<string> GetUserIdentityAsync()
    {
        var isAuthenticated = await IsAuthenticatedAsync();

        if (isAuthenticated == true && _userIdentity == null)
        {
            var tokenResult = await _context.UserTokens
                .Select(ut => new
                {
                    ut.TokenHash,
                    ut.UserIdentity
                })
                .FirstOrDefaultAsync(ut => ut.TokenHash == _tokenProvider.TokenHash);

            _userIdentity = tokenResult.UserIdentity;
        }

        return _userIdentity;
    }

    public async Task<bool> HasPermissionAsync(params PermissionCode[] permissionCodes)
    {
        foreach (var permission in permissionCodes)
        {
            if (await HasPermissionAsync(permission.ToString()))
                return true;
        }

        return false;
    }

    public override async Task<bool> HasPermissionAsync(string permissionCode)
    {
        var isAuthenticated = await IsAuthenticatedAsync();

        if (!isAuthenticated)
            return false;

        var permissions = await GetPermissionsAsync();

        return permissions.Contains(permissionCode);
    }

    public override void ResetUserIdentity(string userIdentity)
        => ResetUserIdentity(userIdentity, nameof(AuthenticationTypeConst.SYSTEM));

    public override void ResetUserIdentity(string userIdentity,
                                           string authenticationType)
    {
        Clear();

        base.ResetUserIdentity(userIdentity);

        _userIdentity = userIdentity;
    }

    private HashSet<string> _permissions;
    public override async Task<HashSet<string>> GetPermissionsAsync()
    {
        var isAuthenticated = await IsAuthenticatedAsync();

        if (isAuthenticated && _permissions == null)
        {
            var user = await GetUserAsync();

            _permissions = user.Permissions.ToHashSet();
        }

        return _permissions;
    }

    protected override bool ValidateAuthenticationType(string authenticationType)
        => Enum.GetValues(typeof(AuthenticationTypeConst))
           .Cast<AuthenticationTypeConst>()
           .Select(x => x.ToString())
           .Contains(authenticationType);

    protected override void Clear()
    {
        base.Clear();
        _permissions = null;
        _user = null;
        _userId = null;
        _userIdentity = null;
    }
}
