using Bms.WEBASE.Extensions;
using WEBASE.Security.Abstraction;

namespace Bms.WEBASE.Security;

public abstract class BaseAsycAuthService :
    IAsyncBaseAuthService
{
    private readonly ITokenProvider _tokenProvider;
    private readonly IAsyncTokenService _tokenService;

    public BaseAsycAuthService(
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
    public abstract Task<string> GetUserIdentityAsync();

    private bool? _isAuthenticated = null;
    public virtual async Task<bool> IsAuthenticatedAsync()
    {
        if (_isAuthenticated == null)
        {
            string token = _tokenProvider.Token;
            _isAuthenticated = await _tokenService.ValidateTokenAsync(token);
        }

        return _isAuthenticated.Value;
    }

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

    }

    protected abstract bool ValidateAuthenticationType(string authenticationType);
}
