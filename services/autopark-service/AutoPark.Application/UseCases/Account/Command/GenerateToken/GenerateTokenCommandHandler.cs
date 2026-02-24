using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE.Security.Abstraction;

namespace AutoPark.Application.UseCases.Accounts;

public class GenerateTokenCommandHandler :
    IRequestHandler<GenerateTokenCommand, UserTokenInfoDto>
{
    private readonly IAsyncAppTokenService _tokenService;
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GenerateTokenCommandHandler(IAsyncAppTokenService tokenService,
                                       IWriteEfCoreContext context,
                                       IMapProvider mapper)
    {
        _tokenService = tokenService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserTokenInfoDto> Handle(GenerateTokenCommand request,
                                             CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Where(u => u.UserName == request.UserIdentity)
            .IsSoftActive()
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
            throw ClientLogicalExceptionHelper.UserNotFound();

        bool validPassword = new CustomPasswordHelper()
            .ValidateHashedPassword(user.PasswordHash,
                                    request.Password,
                                    user.PasswordSalt);

        if (!validPassword)
            throw ClientLogicalExceptionHelper.InvlalidPassword();

        TokenResult accessTokenResult = await GenerateAccessToken(user, cancellationToken);

        TokenResult refreshTokenResult = await GenerateRefreshToken(user, cancellationToken);

        //This code can be change future because double call for one user's info to database first is at the beginning of method and this one
        var userInfo = await _mapper.MapCollection<User, UserInfoDto>(_context.Users.IsSoftActive())
            .FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken);

        userInfo.ResolvePermissions();

        var result = new UserTokenInfoDto
        {
            AccessToken = accessTokenResult.Token,
            AccessTokenExpireAt = accessTokenResult.ExpireAt,
            RefreshToken = refreshTokenResult.Token,
            RefreshTokenExpireAt = refreshTokenResult.ExpireAt,
            UserInfo = userInfo
        };

        result.UserInfo.UserAccess = new();

        if (userInfo.Permissions.Contains(nameof(PermissionCode.OrganizationAllView)))
            result.UserInfo.UserAccess.CanViewAllOrganizations = true;
        await _context.SaveChangesAsync(cancellationToken);

        return result;
    }

    private async Task<TokenResult> GenerateAccessToken(User user,
                                            CancellationToken cancellationToken)
    {
        TokenResult accessTokenResult = await _tokenService.GenerateTokenAsync(user.UserName);

        string hashedAccessToken = HashHelper.ComputeSimpleHash(accessTokenResult.Token);

        user.AddToken(userIdentity: user.UserName,
                      expireAt: accessTokenResult.ExpireAt,
                      tokenHash: hashedAccessToken);

        return accessTokenResult;

    }

    private async Task<TokenResult> GenerateRefreshToken(User user,
                                             CancellationToken cancellationToken)
    {
        TokenResult refreshTokenResult = await _tokenService.GenerateRefreshTokenAsync();

        string hashedRefreshToken = HashHelper.ComputeSimpleHash(refreshTokenResult.Token);

        user.AddRefreshToken(expireAt: refreshTokenResult.ExpireAt,
                             tokenHash: hashedRefreshToken);

        return refreshTokenResult;
    }
}
