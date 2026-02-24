using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class GetServiceTypeByIdQueryHandler :
    IRequestHandler<GetServiceTypeByIdQuery, ServiceTypeDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    public GetServiceTypeByIdQueryHandler(IReadEfCoreContext context,
                                   IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceTypeDto> Handle(
		GetServiceTypeByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _context.ServiceTypes
			.IsSoftActive()
            .Where(b => b.Id == request.Id);

        var dto = await _mapper.MapCollection<ServiceType, ServiceTypeDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        return dto;
    }
}
