using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.Branches;

public class GetBranchBriefPagedResultHandler :
    IRequestHandler<GetBranchBriefPagedResultQuery, PagedResultWithActionControls<BranchBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetBranchBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<BranchBriefDto>> Handle(
        GetBranchBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Branch, BranchBriefDto>(_context.Branches.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.BranchCreate)
        };

        return await query.AsPagedResultWithActionControlAsync(request,
                                                               actionControls: actionControls,
                                                               cancellationToken: cancellationToken);
    }
}