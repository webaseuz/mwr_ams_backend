namespace WEBASE.Security.Abstraction;

public interface IAsyncTokenService
{
    /// <summary>
    /// Generate access token by userIdentity (username or email something like that)
    /// </summary>
    /// <param name="userIdentity"></param>
    /// <returns></returns>
    Task<TokenResult> GenerateTokenAsync(string userIdentity);

    /// <summary>
    /// Generate access token by login ,expireInterval that token will expire
    /// </summary>
    /// <param name="userIdentity"></param>
    /// <param name="expireInterval"></param>
    /// <returns></returns>
    Task<TokenResult> GenerateTokenAsync(string userIdentity, TimeSpan expireInterval);

    /// <summary>
    /// Validate token  
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<bool> ValidateTokenAsync(string token);
}

public interface IAsyncRefreshableTokenService :
    IAsyncTokenService
{
    /// <summary>
    /// Generate refresh token
    /// </summary>
    /// <returns></returns>
    Task<TokenResult> GenerateRefreshTokenAsync();
    /// <summary>
    /// Generate refresh token with expireInterval that token will expire
    /// </summary>
    /// <returns></returns>
    Task<TokenResult> GenerateRefreshTokenAsync(TimeSpan expireInterval);
    /// <summary>
    /// Generate access token by refresh token
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    Task<TokenResult> GenerateTokenByRefreshAsync(string refreshToken);
    /// <summary>
    /// Generate access token by refresh token , expireInterval that token will expire
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    Task<TokenResult> GenerateTokenByRefreshAsync(string refreshToken, TimeSpan expireInterval);
    /// <summary>
    /// validate refresh token
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    Task<bool> ValidateRefreshTokenAsync(string refreshToken);
}