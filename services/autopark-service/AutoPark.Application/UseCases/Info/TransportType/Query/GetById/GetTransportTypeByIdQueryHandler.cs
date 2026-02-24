using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportTypes;

public class GetTransportTypeByIdQueryHandler :
    IRequestHandler<GetTransportTypeByIdQuery, TransportTypeDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetTransportTypeByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TransportTypeDto> Handle(
        GetTransportTypeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.TransportTypes
            .IsSoftActive()
            .Where(x => x.Id == request.Id);

        var dto = await _mapper.MapCollection<TransportType, TransportTypeDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
