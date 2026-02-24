using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TransportSettings;

public class GetTransportSettingByIdQueryHandler :
    IRequestHandler<GetTransportSettingByIdQuery, TransportSettingDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetTransportSettingByIdQueryHandler(IReadEfCoreContext context,
                                               IMapProvider mapper,
                                               IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<TransportSettingDto> Handle(GetTransportSettingByIdQuery request, CancellationToken cancellationToken)
    {
        var query = _context.TransportSettings
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<TransportSetting, TransportSettingDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        var fuelCardNumbers = await _context.FuelCards
           .Where(x => x.TransportId == dto.TransportId)
           .FirstOrDefaultAsync();

        dto.FuelCardNumber = fuelCardNumbers?.CardNumber ?? string.Empty;

        var permissions = await _authService.GetPermissionsAsync();

        dto.CanCreateForAllBranch = permissions.Contains(nameof(PermissionCode.TransportSettingViewAll));

        return dto;
    }
}
