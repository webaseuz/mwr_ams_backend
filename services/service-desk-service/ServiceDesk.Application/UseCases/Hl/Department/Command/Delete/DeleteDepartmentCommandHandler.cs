using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Departments;

public class DeleteDepartmentCommandHandler :
    IRequestHandler<DeleteDepartmentCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteDepartmentCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteDepartmentCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = await _context.Departments
            .IsSoftActive()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
