using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class DeleteMobileAppVersionCommandHandler :
    IRequestHandler<DeleteMobileAppVersionCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteMobileAppVersionCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteMobileAppVersionCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.MobileAppVersions
            .IsSoftActive()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
