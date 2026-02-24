using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class GetPresentTrackingInfoByIdQueryHandler :
        IRequestHandler<GetPresentTrackingInfoByIdQuery, PresentTrackingInfoDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetPresentTrackingInfoByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PresentTrackingInfoDto> Handle(GetPresentTrackingInfoByIdQuery request,
                                  CancellationToken cancellationToken)
    {
        var query = _context.PresentTrackingInfos
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<PresentTrackingInfo, PresentTrackingInfoDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}