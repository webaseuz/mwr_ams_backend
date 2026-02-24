using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class GetInsuranceTypeBriefPagedResultQueryHandler :
    IRequestHandler<GetInsuranceTypeBriefPagedResultQuery, PagedResultWithActionControls<InsuranceTypeBriefDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetInsuranceTypeBriefPagedResultQueryHandler(
        IReadEfCoreContext context,
        IAsyncAppAuthService authService,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<InsuranceTypeBriefDto>> Handle(
        GetInsuranceTypeBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<InsuranceType, InsuranceTypeBriefDto>(_context.InsuranceTypes.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.InsuranceTypeCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);
        result.Rows = await result.Rows.SetActionControls(_authService);
        return result;
    }
}

public static class InsuranceTypeBriefDtoExtension
{
    public static async Task<IEnumerable<InsuranceTypeBriefDto>> SetActionControls(this IEnumerable<InsuranceTypeBriefDto> query,
                                                                               IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.InsuranceTypeView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.InsuranceTypeEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.InsuranceTypeDelete));
        }

        return query;
    }
}
