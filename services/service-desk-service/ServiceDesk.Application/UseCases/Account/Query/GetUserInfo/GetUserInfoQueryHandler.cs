using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Accounts;

public class GetUserInfoQueryHandler :
    IRequestHandler<GetUserInfoQuery, UserInfoDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetUserInfoQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _mapper = mapper;
        _authService = authService;
        _context = context;
    }

    public async Task<UserInfoDto> Handle(GetUserInfoQuery request,
                                               CancellationToken cancellationToken)
    {
        var userIdentity = await _authService.GetUserIdentityAsync();

        var userInfo = await _mapper.MapCollection<User, UserInfoDto>(_context.Users.IsSoftActive())
            .FirstOrDefaultAsync(u => u.UserName == userIdentity, cancellationToken);

        if (userInfo == null)
            throw ClientLogicalExceptionHelper.UserNotFound();

        userInfo.ResolvePermissions();

        return userInfo;
    }
}
