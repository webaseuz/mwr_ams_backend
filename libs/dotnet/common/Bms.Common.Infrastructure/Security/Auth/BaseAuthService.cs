using Bms.WEBASE.Extensions;
using WEBASE.Security.Abstraction;

namespace Bms.WEBASE.Security;

public abstract class BaseAuthService :
    IBaseAuthService
{
    private readonly ITokenProvider _tokenProvider;
    private readonly IAsyncTokenService _tokenService;

    public BaseAuthService(
        ITokenProvider tokenProvider,
        IAsyncTokenService tokenService
        )
    {
        _tokenProvider = tokenProvider;
        _tokenService = tokenService;
    }

    private string _authenticationType = null;
    public virtual string AuthenticationType
    {
        get => _authenticationType;
        set
        {
            if (!ValidateAuthenticationType(value))
                throw new Exception("Invalid authentication type"); //  this "throw"  will be given by standart webase error code instead of default

            _authenticationType = value;
        }
    }

    public abstract Task<HashSet<string>> GetPermissionsAsync();
    public abstract Task<object> GetUserIdAsync();

    private bool? _isAuthenticated = null;

    public virtual async Task<bool> IsAuthenticatedAsync()
    {
        if (!_isAuthenticated.HasValue)
        {
            string token = _tokenProvider.Token;

            _isAuthenticated = await _tokenService.ValidateTokenAsync(token);
        }

        return _isAuthenticated.Value;
    }

    public virtual async Task<bool> IsAuthenticatedAsync(string token)
    {
        if (!_isAuthenticated.HasValue)
        {
            if (token is not null)
                _tokenProvider.SetToken(token);

            token = _tokenProvider.Token;

            _isAuthenticated = await _tokenService.ValidateTokenAsync(token);
        }

        return _isAuthenticated.Value;
    }
    public abstract Task<string> GetUserIdentityAsync();

    public abstract Task<bool> HasPermissionAsync(string permissionCode);

    public virtual void ResetUserIdentity(string userIdentity)
        => ResetUserIdentity(userIdentity, nameof(AuthenticationTypeConst.SYSTEM));

    public virtual void ResetUserIdentity(string userIdentity,
                                          string authenticationType)
    {
        if (userIdentity == null)
            throw new ArgumentNullException(nameof(userIdentity));

        if (authenticationType == null)
            throw new ArgumentNullException(nameof(authenticationType));

        if (userIdentity.NullOrWhiteSpace())
            throw new ArgumentException(nameof(userIdentity));


        Clear();
        _isAuthenticated = true;
        AuthenticationType = authenticationType;
    }

    /// <summary>
    /// This must be overriden in class that inheret this class
    /// </summary>
    protected virtual void Clear()
    {
        _isAuthenticated = null;
    }

    protected abstract bool ValidateAuthenticationType(string authenticationType);
}