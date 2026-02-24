using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class GetDeviceSpareTypeByIdQueryHandler :
    IRequestHandler<GetDeviceSpareTypeByIdQuery, DeviceSpareTypeDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    public GetDeviceSpareTypeByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DeviceSpareTypeDto> Handle(
		GetDeviceSpareTypeByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _context.DeviceSpareTypes
			.IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<DeviceSpareType, DeviceSpareTypeDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
