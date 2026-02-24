using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TireModels;

public class GetTireModelByIdQueryHandler :
    IRequestHandler<GetTireModelByIdQuery, TireModelDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    public GetTireModelByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TireModelDto> Handle(
        GetTireModelByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.TireModels
            .Where(x => x.Id == request.Id);

        var dto = await _mapper.MapCollection<TireModel, TireModelDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto is null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
