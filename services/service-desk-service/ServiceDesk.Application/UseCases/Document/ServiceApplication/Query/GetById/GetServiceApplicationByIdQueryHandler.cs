using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class GetServiceApplicationByIdQueryHandler :
    IRequestHandler<GetServiceApplicationByIdQuery, ServiceApplicationDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetServiceApplicationByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<ServiceApplicationDto> Handle(
        GetServiceApplicationByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _context.ServiceApplications
            .Include(x => x.ServiceApplicationFiles)
            .Include(x => x.ServiceApplicationExecutorFiles)
            .Include(x => x.ServiceApplicationHistories)
            .Include(x => x.ServiceApplicationParts)
            .Include(x => x.ServiceApplicationSpares)
            .Where(x => x.Id == request.Id);

        var dto = await _mapper.MapCollection<ServiceApplication, ServiceApplicationDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto is null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        dto.CanCreateForAllBranch 
            = await _authService.HasPermissionAsync(nameof(PermissionCode.AllViewServiceApplication));

        dto.CanEditExecutor = dto.StatusId == StatusIdConst.IN_PROCESS || dto.StatusId == StatusIdConst.CANCELED_BY_CLIENT;
       
        return dto;
    }
}
