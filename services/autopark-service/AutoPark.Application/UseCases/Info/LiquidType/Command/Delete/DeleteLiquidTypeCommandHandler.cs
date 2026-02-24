using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class DeleteLiquidTypeCommandHandler :
      IRequestHandler<DeleteLiquidTypeCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteLiquidTypeCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SuccessResult<bool>> Handle(
        DeleteLiquidTypeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.LiquidTypes
            .Where(a => a.StateId == StateIdConst.ACTIVE)
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
