using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.MobileAppVersions;

public class GetLastMobileAppVersionQueryHandler :
    IRequestHandler<GetLastMobileAppVersionQuery, MobileAppVersionDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetLastMobileAppVersionQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<MobileAppVersionDto> Handle(
        GetLastMobileAppVersionQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.MobileAppVersions
            .IsSoftActive()
            .OrderByDescending(x => x.ReleaseAt);

        var dto = await _mapper.MapCollection<MobileAppVersion, MobileAppVersionDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.Wrap("Активная версия мобильного приложения не найдена", ErrorCode.CLIENT_NOT_FOUND);

        return dto;
    }
}