using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.OilTypes;

public class GetOilTypeByIdQueryHandler :
    IRequestHandler<GetOilTypeByIdQuery, OilTypeDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    public GetOilTypeByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OilTypeDto> Handle(
        GetOilTypeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.OilTypes
            .Where(x => x.Id == request.Id);

        var dto = await _mapper.MapCollection<OilType, OilTypeDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto is null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
