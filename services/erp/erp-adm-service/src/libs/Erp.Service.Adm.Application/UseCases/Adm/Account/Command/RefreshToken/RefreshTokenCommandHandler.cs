using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class RefreshTokenCommandHandler(
    IApplicationDbContext context,
    ITokenService tokenService,
    IPasswordHasher passwordHasher) : IRequestHandler<RefreshTokenCommand, TokenResultDto>
{
    public async Task<TokenResultDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var result = new TokenResultDto();
        var hashOfToken = passwordHasher.Compute(request.RefreshToken);

        var user = await context.Users
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(rt => rt.TokenHash == hashOfToken), cancellationToken);

        if (user == null)
            return result;

        var accessTokenResult = await tokenService.GenerateTokenAsync(user.UserName);
        if (accessTokenResult == null)
            return result;

        var refreshToken = await tokenService.GenerateRefreshTokenAsync();
        if (refreshToken == null)
            return result;

        await context.UserTokens.AddAsync(new UserToken
        {
            UserId = user.Id,
            UserIdentity = user.UserName,
            TokenHash = passwordHasher.Compute(accessTokenResult.Token),
            ExpireAt = accessTokenResult.ExpireAt
        }, cancellationToken);

        await context.UserRefreshTokens.AddAsync(new UserRefreshToken
        {
            UserId = user.Id,
            TokenHash = passwordHasher.Compute(refreshToken.Token),
            ExpireAt = refreshToken.ExpireAt
        }, cancellationToken);

        await context.UserRefreshTokens
            .Where(ur => ur.TokenHash == hashOfToken)
            .ExecuteUpdateAsync(ur =>
                ur.SetProperty(u => u.IsDeleted, u => true), cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        result.AccessToken = accessTokenResult.Token;
        result.AccessTokenExpireAt = accessTokenResult.ExpireAt;
        result.RefreshToken = refreshToken.Token;
        result.RefreshTokenExpireAt = refreshToken.ExpireAt;

        return result;
    }
}
