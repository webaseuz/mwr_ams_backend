using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Devices;

public class GetDeviceByIdQueryHandler :
    IRequestHandler<GetDeviceByIdQuery, DeviceDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetDeviceByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper,
                                   IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }
    public async Task<DeviceDto> Handle(GetDeviceByIdQuery request, 
                                  CancellationToken cancellationToken)
    {
        var query = _context.Devices
            .IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<Device, DeviceDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        var user = await _authService.GetUserAsync();

        dto.CanCreateForAllBranch = user.Permissions.Contains(nameof(PermissionCode.DeviceViewAll));

        return dto;
    }
}
