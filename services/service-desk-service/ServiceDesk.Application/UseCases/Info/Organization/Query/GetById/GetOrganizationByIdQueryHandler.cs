using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Organizations;

public class GetOrganizationByIdQueryHandler :
	IRequestHandler<GetOrganizationByIdQuery, OrganizationDto>
{
	private readonly IReadEfCoreContext _context;
	private readonly IMapProvider _mapper;
    public GetOrganizationByIdQueryHandler(
		IReadEfCoreContext context,
		IMapProvider mapper)
    {
		_context = context;
		_mapper = mapper;
    }

	public async Task<OrganizationDto> Handle(
		GetOrganizationByIdQuery request,
		CancellationToken cancellationToken)
	{
		var query = _context.Organizations
			.Where(x => x.Id == request.Id);

		var dto = await _mapper.MapCollection<Organization, OrganizationDto>(query)
			.FirstOrDefaultAsync(cancellationToken);

		if (dto is null)
			throw ClientLogicalExceptionHelper.NotFound(request.Id);

		return dto;
	}
}
