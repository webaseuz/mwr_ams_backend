using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Positions;

public class DeletePositionCommandHandler :
	IRequestHandler<DeletePositionCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeletePositionCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeletePositionCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = await _context.Positions
            .IsSoftActive()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
