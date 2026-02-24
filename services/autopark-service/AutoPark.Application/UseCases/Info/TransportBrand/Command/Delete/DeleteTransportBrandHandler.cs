using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportBrands;

public class DeleteTransportBrandHandler :
    IRequestHandler<DeleteTransportBrandCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteTransportBrandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteTransportBrandCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.TransportBrands
            .IsSoftActive()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
