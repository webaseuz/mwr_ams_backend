using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Refuels;

public class GetRefuelByIdQueryHandler :
    IRequestHandler<GetRefuelByIdQuery, RefuelDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetRefuelByIdQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<RefuelDto> Handle(
        GetRefuelByIdQuery request,
        CancellationToken cancellationToken)
    {
        var query = _context.Refuels
            .Where(x => x.Id == request.Id);

        var dto = await _mapper.MapCollection<Refuel, RefuelDto>(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto is null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        var permissions = await _authService.GetPermissionsAsync();

        dto.CanCreateForAllBranch = permissions.Contains(nameof(PermissionCode.RefuelViewAll));

        return dto;
    }

}