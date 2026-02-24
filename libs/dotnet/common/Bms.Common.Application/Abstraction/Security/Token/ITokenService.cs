namespace WEBASE.Security.Abstraction;

public interface ITokenService
{
    /// <summary>
    /// Generate access token by userIdentity (username or email something like that)
    /// </summary>
    /// <param name="userIdentity"></param>
    /// <returns></returns>
    TokenResult GenerateToken(string userIdentity);

    /// <summary>
    /// Generate access token by login ,expireInterval that token will expire
    /// </summary>
    /// <param name="userIdentity"></param>
    /// <param name="expireInterval"></param>
    /// <returns></returns>
    TokenResult GenerateToken(string userIdentity, TimeSpan expireInterval);

    /// <summary>
    /// Validate token
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    bool ValidateToken(string token);
}

public interface IRefreshableTokenService :
    ITokenService
{
    /// <summary>
    /// Generate refresh token
    /// </summary>
    /// <returns></returns>
    TokenResult GenerateRefreshToken();
    /// <summary>
    /// Generate refresh token with expireInterval that token will expire
    /// </summary>
    /// <returns></returns>
    TokenResult GenerateRefreshToken(TimeSpan expireInterval);
    /// <summary>
    /// Generate access token by refresh token
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    TokenResult GenerateTokenByRefresh(string refreshToken);
    /// <summary>
    /// Generate access token by refresh token , expireInterval that token will expire
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    TokenResult GenerateTokenByRefresh(string refreshToken, TimeSpan expireInterval);
    /// <summary>
    /// validate refresh token
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    bool ValidateRefreshToken(string refreshToken);
}