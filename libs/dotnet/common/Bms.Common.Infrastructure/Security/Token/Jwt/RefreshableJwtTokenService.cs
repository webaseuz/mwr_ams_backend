using System.Security.Cryptography;
using WEBASE.Security.Abstraction;

namespace Bms.WEBASE.Security;

public abstract class RefreshableJwtTokenService :
    JwtTokenService,
    IRefreshableJwtTokenService
{
    private readonly RefreshableJwtConfig _config;
    private readonly ITokenProvider _tokenProvider;

    public RefreshableJwtTokenService(
        RefreshableJwtConfig config,
        ITokenProvider tokenProvider)
        : base(config)
    {
        _config = config;
        _tokenProvider = tokenProvider;
    }

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

    /// <summary>
    /// This must be overriden and check if there is refresh in db or not also.If you will store token in DB
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    public abstract bool ValidateRefreshToken(string refreshToken);

}
