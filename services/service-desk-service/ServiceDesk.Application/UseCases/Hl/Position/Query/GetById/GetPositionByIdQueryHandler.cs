using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Positions;

public class GetPositionByIdQueryHandler :
    IRequestHandler<GetPositionByIdQuery, PositionDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetPositionByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PositionDto> Handle(
        GetPositionByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.Positions
            .IsSoftActive()
            .Where(x => x.Id == request.Id);

        var dto = await _mapper.MapCollection<Position, PositionDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
