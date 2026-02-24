using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Organizations;

public class DeleteOrganizationHandler :
	IRequestHandler<DeleteOrganizationCommand, SuccessResult<bool>>
{
	private readonly IWriteEfCoreContext _context;

    public DeleteOrganizationHandler(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SuccessResult<bool>> Handle(
		DeleteOrganizationCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.Organizations
			.IsSoftActive()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

		if (entity == null)
			throw ClientLogicalExceptionHelper.NotFound(request.Id);

		entity.MarkAsPassive();

		await _context.SaveChangesAsync(cancellationToken);

		return SuccessResult.Create(true);
	}
}
