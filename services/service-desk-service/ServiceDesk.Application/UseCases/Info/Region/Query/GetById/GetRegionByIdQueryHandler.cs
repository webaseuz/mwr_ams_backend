using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Regions;

public class GetRegionByIdQueryHandler :
	IRequestHandler<GetRegionByIdQuery, RegionDto>
{
	private readonly IReadEfCoreContext _context;
	private readonly IMapProvider _mapper;
    public GetRegionByIdQueryHandler(
		IReadEfCoreContext context,
		IMapProvider mapper)
    {
		_context = context;
		_mapper = mapper;
    }

	public async Task<RegionDto> Handle(
		GetRegionByIdQuery request,
		CancellationToken cancellationToken)
	{
		var query = _context.Regions
			.Where(x => x.Id == request.Id);

		var dto = await _mapper.MapCollection<Region, RegionDto>(query)
			.FirstOrDefaultAsync(cancellationToken);

		if (dto is null)
			throw ClientLogicalExceptionHelper.NotFound(request.Id);

		return dto;
	}
}
