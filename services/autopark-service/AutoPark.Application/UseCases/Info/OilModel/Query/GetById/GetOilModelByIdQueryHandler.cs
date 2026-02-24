using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.OilModels;

public class GetOilModelByIdQueryHandler :
    IRequestHandler<GetOilModelByIdQuery, OilModelDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    public GetOilModelByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OilModelDto> Handle(
        GetOilModelByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.OilModels
            .Where(x => x.Id == request.Id);

        var dto = await _mapper.MapCollection<OilModel, OilModelDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto is null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
