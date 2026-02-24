using Bms.WEBASE.Extensions;
using Bms.WEBASE.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application;
using ServiceDesk.Application.Security;

namespace ServiceDesk.Application.UseCases.Accounts;

public class RefreshTokenCommandHandler :
    IRequestHandler<RefreshTokenCommand, TokenResultDto>
{
    private readonly IAsyncAppTokenService _tokenService;
    private readonly IWriteEfCoreContext _context;

    public RefreshTokenCommandHandler(
        IAsyncAppTokenService tokenService,
        IWriteEfCoreContext context)
    {
        _tokenService = tokenService;
        _context = context;
    }

    public async Task<TokenResultDto> Handle(RefreshTokenCommand request,
                                       CancellationToken cancellationToken)
    {
        var result = new TokenResultDto();
        var hashOfToken = HashHelper.ComputeSimpleHash(request.RefreshToken);

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(rt => rt.TokenHash == hashOfToken));

        if (user == null)
            return result;

        var accessTokenResult = await _tokenService.GenerateTokenAsync(user.UserName);

        if (accessTokenResult.IsNullOrEmptyObject())
            return result;

        var refreshToken = await _tokenService.GenerateRefreshTokenAsync();

        if (refreshToken.IsNullOrEmptyObject())
            return result;

        user.AddToken(user.UserName,
                      HashHelper.ComputeSimpleHash(accessTokenResult.Token),
                      accessTokenResult.ExpireAt);

        user.AddRefreshToken(HashHelper.ComputeSimpleHash(refreshToken.Token),
                             refreshToken.ExpireAt);

        await _context.UserRefreshTokens
                .Where(ur => ur.TokenHash == hashOfToken)
                .ExecuteUpdateAsync(ur =>
                    ur.SetProperty(u => u.IsDeleted, u => true));

        await _context.SaveChangesAsync(cancellationToken);

        result.AccessToken = accessTokenResult.Token;
        result.AccessTokenExpireAt = accessTokenResult.ExpireAt;
        result.RefreshToken = refreshToken.Token;
        result.RefreshTokenExpireAt = refreshToken.ExpireAt;

        return result;
    }
}
