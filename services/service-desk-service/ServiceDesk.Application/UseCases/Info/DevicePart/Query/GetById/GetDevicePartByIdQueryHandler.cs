using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class GetDevicePartByIdQueryHandler :
    IRequestHandler<GetDevicePartByIdQuery, DevicePartDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    public GetDevicePartByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DevicePartDto> Handle(
		GetDevicePartByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _context.DeviceParts
			.IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<DevicePart, DevicePartDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
