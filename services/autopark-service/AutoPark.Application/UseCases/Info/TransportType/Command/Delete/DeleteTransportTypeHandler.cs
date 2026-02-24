using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportTypes;

public class DeleteTransportTypeHandler :
    IRequestHandler<DeleteTransportTypeCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteTransportTypeHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteTransportTypeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.TransportTypes
            .IsSoftActive()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
