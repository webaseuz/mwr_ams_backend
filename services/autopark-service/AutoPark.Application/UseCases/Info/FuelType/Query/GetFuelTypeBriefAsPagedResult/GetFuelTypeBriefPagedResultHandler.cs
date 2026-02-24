using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.FuelTypes;

public class GetFuelTypeBriefPagedResultHandler :
    IRequestHandler<GetFuelTypeBriefPagedResultQuery, PagedResultWithActionControls<FuelTypeBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetFuelTypeBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<FuelTypeBriefDto>> Handle(
        GetFuelTypeBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<FuelType, FuelTypeBriefDto>(_context.FuelTypes.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.FuelTypeCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}

public static class FuelTypeBriefDtoExtension
{
    public static async Task<IEnumerable<FuelTypeBriefDto>> SetActionControls(this IEnumerable<FuelTypeBriefDto> query,
                                                                               IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.FuelTypeView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.FuelTypeEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.FuelTypeDelete));
        }



        return query;
    }
}