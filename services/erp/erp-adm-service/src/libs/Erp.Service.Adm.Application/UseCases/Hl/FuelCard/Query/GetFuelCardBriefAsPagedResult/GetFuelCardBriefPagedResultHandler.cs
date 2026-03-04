using AutoMapper;
using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.EntityFramework.Abstraction;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

public class GetFuelCardBriefPagedResultHandler : IRequestHandler<FuelCardGetListQuery, WbPagedResult<FuelCardBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICultureHelper _cultureHelper;
    private readonly IMainAuthService _authService;

    public GetFuelCardBriefPagedResultHandler(
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

    public async Task<WbPagedResult<FuelCardBriefDto>> Handle(FuelCardGetListQuery request, CancellationToken cancellationToken)
    {
        var userInfo = _authService.User;

        if (!userInfo.Permissions.Contains(nameof(PermissionCode.FuelCardViewAll)))
            request.BranchId = userInfo.BranchId;

        var query = _context.FuelCards
            .Where(x => x.StateId == WbStateIdConst.ACTIVE)
            .MapTo<FuelCardBriefDto>(_mapper, _cultureHelper);

        if (request.BranchId.HasValue)
            query = query.Where(x => x.BranchId == request.BranchId);

        if (request.DriverId.HasValue)
            query = query.Where(x => x.DriverId == request.DriverId);

        if (request.TransportId.HasValue)
            query = query.Where(x => x.TransportId == request.TransportId);

        if (request.PlasticCardTypeId.HasValue)
            query = query.Where(x => x.PlasticCardTypeId == request.PlasticCardTypeId);

        if (!string.IsNullOrWhiteSpace(request.CardNumber))
            query = query.Where(x => x.CardNumber.Contains(request.CardNumber));

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var target = request.Search.ToLower();
            query = query.Where(x =>
                x.CardNumber.ToLower().Contains(target) ||
                x.DriverName.ToLower().Contains(target) ||
                x.TransportModelName.ToLower().Contains(target) ||
                x.TransportStateNumber.ToLower().Contains(target) ||
                x.PlasticCardTypeName.ToLower().Contains(target));
        }

        return await query.AsPagedResultAsync(request);
    }
}
