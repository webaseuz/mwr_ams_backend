using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class GetSpareMovementByIdQueryHandler :
    IRequestHandler<GetSpareMovementByIdQuery, SpareMovementDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetSpareMovementByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<SpareMovementDto> Handle(
		GetSpareMovementByIdQuery request, 
        CancellationToken cancellationToken)
    {
        var query = _context.SpareMovements
            .Include(x => x.Tables)
		    .Where(x => x.Id == request.Id);

        var dto = await _mapper.MapCollection<SpareMovement, SpareMovementDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto is null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        dto.CanCreateForAllBranch = await _authService.HasPermissionAsync(nameof(PermissionCode.SpareMovementAllView));

        return dto;
    }
}
