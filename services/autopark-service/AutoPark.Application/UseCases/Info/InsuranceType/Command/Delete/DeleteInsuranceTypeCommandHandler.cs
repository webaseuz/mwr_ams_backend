using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class DeleteInsuranceTypeCommandHandler :
    IRequestHandler<DeleteInsuranceTypeCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;

    public DeleteInsuranceTypeCommandHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteInsuranceTypeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.InsuranceTypes
            .IsSoftActive()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        entity.MarkAsPassive();

        await _context.SaveChangesAsync(cancellationToken);

        return SuccessResult.Create(true);
    }
}
