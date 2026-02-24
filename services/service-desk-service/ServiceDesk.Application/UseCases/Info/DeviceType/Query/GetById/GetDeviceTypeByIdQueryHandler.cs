using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class GetDeviceTypeByIdQueryHandler :
    IRequestHandler<GetDeviceTypeByIdQuery, DeviceTypeDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    public GetDeviceTypeByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DeviceTypeDto> Handle(
		GetDeviceTypeByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _context.DeviceTypes
			.IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<DeviceType, DeviceTypeDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
