using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Currencies;

public class DeleteCurrencyCommandHandler :
    IRequestHandler<DeleteCurrencyCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteCurrencyCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Currencies
            .IsSoftActive()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
