using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class DeleteDeviceModelCommandHandler :
    IRequestHandler<DeleteDeviceModelCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteDeviceModelCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(DeleteDeviceModelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.DeviceModels
			.IsSoftActive()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
