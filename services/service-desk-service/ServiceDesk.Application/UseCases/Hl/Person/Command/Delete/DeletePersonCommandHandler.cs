using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Persons;

public class DeletePersonCommandHandler :
    IRequestHandler<DeletePersonCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeletePersonCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeletePersonCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = await _context.People
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
