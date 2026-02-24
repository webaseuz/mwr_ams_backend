using System.Security.Claims;

namespace WEBASE.Security.Abstraction;

public interface IAsyncJwtTokenService :
    IAsyncTokenService
{
    /// <summary>
    /// Generate JWT token by claims
    /// </summary>
    /// <param name="claims"></param>
    /// <returns></returns>
    Task<TokenResult> GenerateJwtTokenAsync(IEnumerable<Claim> claims);

    /// <summary>
    /// Generate JWT token by claims , expireInterval that token will expire
    /// </summary>
    /// <param name="claims"></param>
    /// <param name="expireInterval"></param>
    /// <returns></returns>
    Task<TokenResult> GenerateJwtTokenAsync(IEnumerable<Claim> claims, TimeSpan expireInterval);

    /// <summary>
    /// Get claims from token
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<Claim[]> GetClaims(string token);
}

public interface IAsyncRefreshableJwtTokenService :
    IAsyncJwtTokenService
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