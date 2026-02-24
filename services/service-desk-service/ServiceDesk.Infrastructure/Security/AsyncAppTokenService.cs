using ServiceDesk.Application;
using ServiceDesk.Application.Security;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Helpers;
using Bms.WEBASE.Security;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using WEBASE.Security.Abstraction;

namespace ServiceDesk.Infrastructure.Security;

public class AsyncAppTokenService :
    AsyncRefreshableReferenceTokenService,
    IAsyncAppTokenService
{
    private readonly IReadEfCoreContext _context;

    public AsyncAppTokenService(RefreshableReferenceTokenConfig config,
                                IReadEfCoreContext context)
        : base(config)
    {
        _context = context;
    }

    public override Task<TokenResult> GenerateTokenAsync(string userIdentity,
                                                               TimeSpan expireInterval)
    {
        if (userIdentity.IsNullOrEmptyObject())
            return null;

        var randomBytes = new byte[64];

        using (var rng = RandomNumberGenerator.Create())
            rng.GetBytes(randomBytes);

        string token = Convert.ToBase64String(randomBytes)
            .Replace('+', '-')
            .Replace('/', '_')
            .Trim('=');

        DateTime expire = DateTime.Now.Add(expireInterval);

        return Task.FromResult(new TokenResult
        {
            ExpireAt = expire,
            Token = token
        });
    }


    public override async Task<TokenResult> GenerateTokenByRefreshAsync(string refreshToken,
                                                                        TimeSpan expireInterval)
    {
        if (refreshToken.IsNullOrEmptyObject())
            return null;

        var hashOfRefreshToken = HashHelper.ComputeSimpleHash(refreshToken);

        var refreshTokenResult = await _context.UserRefreshTokens
            .Where(rt => !rt.IsDeleted &&
                         rt.TokenHash == hashOfRefreshToken &&
                         rt.ExpireAt >= DateTime.Now)
            .Select(rt => new
            {
                UserIdentity = rt.User.UserName
            }).FirstOrDefaultAsync();

        if (refreshTokenResult == null)
            return null;

        var tokenResult = await GenerateTokenAsync(refreshTokenResult.UserIdentity,
                                                   expireInterval);

        return tokenResult;
    }

    public override async Task<bool> ValidateRefreshTokenAsync(string refreshToken)
    {
        if (refreshToken.IsNullOrEmptyObject())
            return false;

        var hashOfToken = HashHelper.ComputeSimpleHash(refreshToken);

        var hasTokenResult = await _context.UserRefreshTokens
            .AnyAsync(rt => !rt.IsDeleted &&
                            rt.TokenHash == hashOfToken &&
                            rt.ExpireAt >= DateTime.Now);

        if (hasTokenResult)
            return true;

        return false;
    }


    public override async Task<bool> ValidateTokenAsync(string token)
    {
        if (token.IsNullOrEmptyObject())
            return false;

        var hashOfToken = HashHelper.ComputeSimpleHash(token);

        var hasTokenResult = await _context.UserTokens
            .AnyAsync(rt => !rt.IsDeleted &&
                            rt.TokenHash == hashOfToken &&
                            rt.ExpireAt >= DateTime.Now);

        if (hasTokenResult)
            return true;

        return false;
    }
}