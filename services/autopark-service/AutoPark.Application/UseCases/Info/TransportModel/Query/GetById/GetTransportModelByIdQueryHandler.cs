using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportModels;

public class GetTransportModelByIdQueryHandler :
    IRequestHandler<GetTransportModelByIdQuery, TransportModelDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetTransportModelByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TransportModelDto> Handle(
        GetTransportModelByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.TransportModels
            .Include(src => src.Liquids)
            .Include(src => src.Oils)
            .Include(src => src.Fuels)
            .IsSoftActive()
            .Where(x => x.Id == request.Id);

        var dto = await _mapper.MapCollection<TransportModel, TransportModelDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
