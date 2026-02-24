using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class GetTransportUseTypeByIdQueryHandler :
    IRequestHandler<GetTransportUseTypeByIdQuery, TransportUseTypeDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetTransportUseTypeByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TransportUseTypeDto> Handle(
        GetTransportUseTypeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.TransportUseTypes
            .IsSoftActive()
            .Where(x => x.Id == request.Id);

        var dto = await _mapper.MapCollection<TransportUseType, TransportUseTypeDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
