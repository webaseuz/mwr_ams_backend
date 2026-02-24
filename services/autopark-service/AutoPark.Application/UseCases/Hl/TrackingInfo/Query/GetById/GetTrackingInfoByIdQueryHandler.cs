using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class GetTrackingInfoByIdQueryHandler :
        IRequestHandler<GetTrackingInfoByIdQuery, TrackingInfoDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetTrackingInfoByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TrackingInfoDto> Handle(GetTrackingInfoByIdQuery request,
                                  CancellationToken cancellationToken)
    {
        var query = _context.TrackingInfos
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<TrackingInfo, TrackingInfoDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}