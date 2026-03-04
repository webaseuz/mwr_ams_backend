using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Roles;

public class DeleteRoleCommandHandler :
    IRequestHandler<DeleteRoleCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteRoleCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteRoleCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Roles
            .IsSoftActive()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
