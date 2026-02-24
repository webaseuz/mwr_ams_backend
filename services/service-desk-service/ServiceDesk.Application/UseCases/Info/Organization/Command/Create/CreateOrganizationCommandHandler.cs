using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Organizations;

public class CreateOrganizationCommandHandler :
	IRequestHandler<CreateOrganizationCommand, IHaveId<int>>
{
	private readonly IWriteEfCoreContext _context;
	private readonly IMapProvider _mapper;

    public CreateOrganizationCommandHandler(IWriteEfCoreContext context, IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
		CreateOrganizationCommand request,
        CancellationToken cancellationToken)
	{
		var entity = request.CreateEntity<CreateOrganizationCommand, Organization>(_mapper);

		request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

		entity.MarkAsActive();

		return HaveId.Create(await _context.CreateAndSaveAsync<int, Organization>(entity, cancellationToken));
	}
}
