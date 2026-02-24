using System.Security.Claims;

namespace WEBASE.Security.Abstraction;

public interface IJwtTokenService :
    ITokenService
{
    /// <summary>
    /// Generate JWT token by claims
    /// </summary>
    /// <param name="claims"></param>
    /// <returns></returns>
    TokenResult GenerateJwtToken(IEnumerable<Claim> claims);

    /// <summary>
    /// Generate JWT token by claims , expireInterval that token will expire
    /// </summary>
    /// <param name="claims"></param>
    /// <param name="expireInterval"></param>
    /// <returns></returns>
    TokenResult GenerateJwtToken(IEnumerable<Claim> claims, TimeSpan expireInterval);

    /// <summary>
    /// Get claims from token
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Claim[] GetClaims(string token);
}

public interface IRefreshableJwtTokenService :
    IJwtTokenService
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
    /// Generate access token by validating refresh token
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    TokenResult GenerateTokenByRefresh(string refreshToken, TimeSpan expireInterval);

    /// <summary>
    /// validate refresh token (This must be overriden and check if there is refresh in db or not also.If you will store token in DB)
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    bool ValidateRefreshToken(string refreshToken);
}