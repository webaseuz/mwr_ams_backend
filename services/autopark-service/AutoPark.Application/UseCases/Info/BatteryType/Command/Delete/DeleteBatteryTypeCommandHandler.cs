using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class DeleteBatteryTypeCommandHandler :
     IRequestHandler<DeleteBatteryTypeCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteBatteryTypeCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteBatteryTypeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.BatteryTypes
            .IsSoftActive()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
