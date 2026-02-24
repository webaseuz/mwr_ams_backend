using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class DeleteDevicePartCommandHandler :
    IRequestHandler<DeleteDevicePartCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteDevicePartCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(DeleteDevicePartCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.DeviceParts
			.IsSoftActive()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
