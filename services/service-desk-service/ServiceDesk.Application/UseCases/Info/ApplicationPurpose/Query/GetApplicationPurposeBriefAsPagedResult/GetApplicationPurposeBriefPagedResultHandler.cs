using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.Core.Application;
using MediatR;
using ServiceDesk.Application.Security;
using ServiceDesk.Application.UseCases.DeviceModels;
using ServiceDesk.Domain;
using Bms.WEBASE.Extensions;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class GetApplicationPurposeBriefPagedResultHandler :
 IRequestHandler<GetApplicationPurposeBriefPagedResultQuery, PagedResultWithActionControls<ApplicationPurposeBriefDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetApplicationPurposeBriefPagedResultHandler(
        IReadEfCoreContext context,
        IAsyncAppAuthService authService,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<ApplicationPurposeBriefDto>> Handle(
        GetApplicationPurposeBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<ApplicationPurpose, ApplicationPurposeBriefDto>(_context.ApplicationPurposes.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.ApplicationPurposeCreate)
        };
        var result = await query.AsPagedResultWithActionControlAsync(request,
                                                                     actionControls,
                                                                     cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}
public static class ApplicationPurposeBriefDtoExtension
{
    public static async Task<IEnumerable<ApplicationPurposeBriefDto>> SetActionControls(this IEnumerable<ApplicationPurposeBriefDto> query,

        IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.ApplicationPurposeView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.ApplicationPurposeEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.ApplicationPurposeDelete));
        }

        return query;
    }
}