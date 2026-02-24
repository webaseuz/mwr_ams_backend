using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Info.Contractors;

public class DeleteContractorCommandHandler :
     IRequestHandler<DeleteContractorCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteContractorCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteContractorCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Contractors
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
