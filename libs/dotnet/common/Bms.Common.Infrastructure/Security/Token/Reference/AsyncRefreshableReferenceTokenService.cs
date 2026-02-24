using System.Security.Cryptography;
using WEBASE.Security.Abstraction;

namespace Bms.WEBASE.Security;

public abstract class AsyncRefreshableReferenceTokenService :
    IAsyncRefreshableReferenceTokenService
{
    private readonly RefreshableReferenceTokenConfig _config;

    public AsyncRefreshableReferenceTokenService(
        RefreshableReferenceTokenConfig config)
        => _config = config;

    public abstract Task<bool> ValidateTokenAsync(string token);

    public abstract Task<TokenResult> GenerateTokenAsync(string userIdentity,
                                                         TimeSpan expireInterval);

    public virtual Task<TokenResult> GenerateTokenAsync(string userIdentity)
        => GenerateTokenAsync(userIdentity, TimeSpan.FromMinutes(_config.Expires));

    public abstract Task<TokenResult> GenerateTokenByRefreshAsync(string refreshToken,
                                                                  TimeSpan expireInterval);

    public abstract Task<bool> ValidateRefreshTokenAsync(string refreshToken);

    public virtual async Task<TokenResult> GenerateRefreshTokenAsync()
     => await GenerateRefreshTokenAsync(TimeSpan.FromMinutes(_config.RefreshExpire));

    public virtual async Task<TokenResult> GenerateTokenByRefreshAsync(string refreshToken)
     => await GenerateTokenByRefreshAsync(refreshToken,
                               TimeSpan.FromMinutes(_config.RefreshExpire));

    public virtual Task<TokenResult> GenerateRefreshTokenAsync(TimeSpan expireInterval)
    {
        var randomBytes = new byte[32];

        using (var rng = RandomNumberGenerator.Create())
            rng.GetBytes(randomBytes);

        string token = Convert.ToBase64String(randomBytes)
            .Replace('+', '-')
            .Replace('/', '_')
            .Trim('=');

        return Task.FromResult(new TokenResult
        {
            Token = token,
            ExpireAt = DateTime.Now.Add(expireInterval)
        });
    }
}