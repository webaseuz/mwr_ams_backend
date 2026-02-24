using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class DeleteServiceTypeCommandHandler :
    IRequestHandler<DeleteServiceTypeCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteServiceTypeCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(DeleteServiceTypeCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == 1)
            throw ClientLogicalExceptionHelper.CanNotPassive($"{request.Id}");

        var entity = await _context.ServiceTypes
			.IsSoftActive()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
