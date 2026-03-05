using AutoMapper;
using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

public class GetDriverBriefPagedResultHandler : IRequestHandler<DriverGetListQuery, WbPagedResult<DriverBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICultureHelper _cultureHelper;
    private readonly IMainAuthService _authService;

    public GetDriverBriefPagedResultHandler(
        IApplicationDbContext context,
        IMapper mapper,
        ICultureHelper cultureHelper,
        IMainAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _cultureHelper = cultureHelper;
        _authService = authService;
    }

    public async Task<WbPagedResult<DriverBriefDto>> Handle(DriverGetListQuery request, CancellationToken cancellationToken)
    {
        var userInfo = _authService.User;

        if (!userInfo.Permissions.Contains(nameof(AdmPermissionCode.AllViewDriver)))
            request.BranchId = userInfo.BranchId;

        var query = _context.Drivers
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<DriverBriefDto>(_mapper, _cultureHelper);

        if (request.BranchId.HasValue)
            query = query.Where(q => q.BranchId == request.BranchId.Value);

        if (request.HasSearch())
        {
            var search = request.Search!.ToLower();
            query = query.Where(a => a.PersonName.ToLower().Contains(search) ||
                                     a.BranchName.ToLower().Contains(search));
        }

        return await query.AsPagedResultAsync(request);
    }
}
