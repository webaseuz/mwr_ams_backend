using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Users;

public class GetUserByIdQueryHandler :
    IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    public GetUserByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper,
                                   IAsyncAppAuthService authService)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        var userInfo = await _authService.GetUserAsync();

        var query = _context.Users
            .Include(u => u.Person)
            .Where(b => b.Id == request.Id);
        if (!userInfo.Permissions.Contains(nameof(PermissionCode.AllUserView)))
            query = query.IsSoftActive();

        var dto = await _mapper.MapCollection<User, UserDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
