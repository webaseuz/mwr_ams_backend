using AutoPark.Application.Security;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Users;

public class UpdateStateUserCommandHandler :
    IRequestHandler<UpdateStateUserCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IAsyncAppAuthService _authService;
    private readonly IMapProvider _mapper;

    public UpdateStateUserCommandHandler(
        IAsyncAppAuthService authService,
        IWriteEfCoreContext context,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
        UpdateStateUserCommand request,
        CancellationToken cancellationToken)
    {

        var userInfo = await _authService.GetUserAsync();

        if (!userInfo.Permissions.Contains(nameof(PermissionCode.AllUserEdit)))
            throw ClientLogicalExceptionHelper.NotAllowedStatus();

        //UserState Update
        var entity = await _context.Users
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        entity.StateId = request.StateId;

        await _context.SaveChangesAsync(cancellationToken);

        return HaveId.Create(request.Id);
    }
}