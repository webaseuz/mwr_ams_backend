using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class GetDeviceModelByIdQueryHandler :
    IRequestHandler<GetDeviceModelByIdQuery, DeviceModelDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    public GetDeviceModelByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DeviceModelDto> Handle(
		GetDeviceModelByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _context.DeviceModels
			.IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<DeviceModel, DeviceModelDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
