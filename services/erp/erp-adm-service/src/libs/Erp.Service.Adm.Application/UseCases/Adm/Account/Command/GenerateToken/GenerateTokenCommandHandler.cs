using AutoMapper;
using AutoMapper.QueryableExtensions;
using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GenerateTokenCommandHandler(
    IApplicationDbContext context,
    ITokenService tokenService,
    IPasswordHasher passwordHasher,
    IMapper mapper,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<GenerateTokenCommand, UserTokenInfoDto>
{
    public async Task<UserTokenInfoDto> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .Where(u => u.UserName == request.UserIdentity && !u.IsDeleted && u.StateId == WbStateIdConst.ACTIVE)
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "USER_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("USER_NOT_FOUND").ToString()
                });

        bool validPassword = passwordHasher.Validate(user.PasswordHash, request.Password, user.PasswordSalt);

        if (!validPassword)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "INVALID_PASSWORD",
                    ErrorMessage = localizationBuilder.For("INVALID_PASSWORD").ToString()
                });

        TokenResult accessTokenResult = await tokenService.GenerateTokenAsync(user.UserName);
        TokenResult refreshTokenResult = await tokenService.GenerateRefreshTokenAsync();

        await context.UserTokens.AddAsync(new UserToken
        {
            UserId = user.Id,
            UserIdentity = user.UserName,
            ExpireAt = accessTokenResult.ExpireAt,
            TokenHash = passwordHasher.Compute(accessTokenResult.Token)
        }, cancellationToken);

        await context.UserRefreshTokens.AddAsync(new UserRefreshToken
        {
            UserId = user.Id,
            ExpireAt = refreshTokenResult.ExpireAt,
            TokenHash = passwordHasher.Compute(refreshTokenResult.Token)
        }, cancellationToken);

        var userInfo = await context.Users
            .Where(u => u.Id == user.Id)
            .ProjectTo<UserInfoDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        userInfo.ResolveModules();

        await context.SaveChangesAsync(cancellationToken);

        var result = new UserTokenInfoDto
        {
            AccessToken = accessTokenResult.Token,
            AccessTokenExpireAt = accessTokenResult.ExpireAt,
            RefreshToken = refreshTokenResult.Token,
            RefreshTokenExpireAt = refreshTokenResult.ExpireAt,
            UserInfo = userInfo
        };

        result.UserInfo.UserAccess = new();

        if (userInfo.Permissions.Contains(nameof(AdmPermissionCode.OrganizationAllView)))
            result.UserInfo.UserAccess.CanViewAllOrganizations = true;

        return result;
    }
}
