using System.Security.Cryptography;
using WEBASE.Security.Abstraction;

namespace Bms.WEBASE.Security;

public abstract class RefreshableReferenceTokenService :
    ITokenService,
    IRefreshableReferenceTokenService
{
    private readonly RefreshableReferenceTokenConfig _config;

    public RefreshableReferenceTokenService(
        RefreshableReferenceTokenConfig config,
        ITokenProvider tokenProvider)
    {
        _config = config;
    }

    public abstract TokenResult GenerateToken(string userIdentity);

    public abstract TokenResult GenerateToken(string userIdentity,
                                              TimeSpan expireInterval);
    public abstract bool ValidateToken(string token);

    public virtual TokenResult GenerateRefreshToken()
     => GenerateRefreshToken(TimeSpan.FromMinutes(_config.RefreshExpire));

    public virtual TokenResult GenerateRefreshToken(TimeSpan expireInterval)
    {
        var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        return new TokenResult
        {
            Token = refreshToken,
            ExpireAt = DateTime.Now.Add(expireInterval)
        };
    }

    public virtual TokenResult GenerateTokenByRefresh(string refreshToken)
     => GenerateTokenByRefresh(refreshToken,
                               TimeSpan.FromMinutes(_config.RefreshExpire));

    public abstract TokenResult GenerateTokenByRefresh(string refreshToken,
                                                      TimeSpan expireInterval);

    public abstract bool ValidateRefreshToken(string refreshToken);

}
