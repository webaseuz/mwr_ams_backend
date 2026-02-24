using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Organizations;

public class UpdateOrganizationCommandHandler :
	IRequestHandler<UpdateOrganizationCommand, IHaveId<int>>
{
	private readonly IWriteEfCoreContext _context;
	private readonly IMapProvider _mapper;

    public UpdateOrganizationCommandHandler(
		IWriteEfCoreContext context,
		IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
		UpdateOrganizationCommand request,
        CancellationToken cancellationToken)
	{
		var entity = await _context.Organizations
			.Include(b => b.Translates)
			.IsSoftActive()
			.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

		if (entity == null)
			throw ClientLogicalExceptionHelper.NotFound(request.Id);

		request.UpdateEntity(entity, _mapper);

		request.Translates.ApplyChangesByUniqueFKTo(entity.Translates, _mapper);

		await _context.SaveChangesAsync(cancellationToken);

		return HaveId.Create(request.Id);
	}
}
