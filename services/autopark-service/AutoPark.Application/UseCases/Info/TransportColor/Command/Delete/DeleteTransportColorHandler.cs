using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportColors;

public class DeleteTransportColorHandler :
    IRequestHandler<DeleteTransportColorCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteTransportColorHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteTransportColorCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.TransportColors
            .IsSoftActive()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
