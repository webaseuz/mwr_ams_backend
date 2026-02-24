using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.Departments;

public class GetDepartmentBriefPagedResultHandler :
    IRequestHandler<GetDepartmentBriefPagedResultQuery, PagedResultWithActionControls<DepartmentBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetDepartmentBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<DepartmentBriefDto>> Handle(
        GetDepartmentBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Department, DepartmentBriefDto>(_context.Departments.IsSoftActive());

        query = await query.SortFilter(request, _authService);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.DepartmentCreate)
        };

        return await query.AsPagedResultWithActionControlAsync(request, actionControls: actionControls, cancellationToken);
    }
}
