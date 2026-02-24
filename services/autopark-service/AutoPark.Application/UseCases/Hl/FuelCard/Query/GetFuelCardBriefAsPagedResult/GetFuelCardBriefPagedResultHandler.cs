using AutoPark.Application.HelperService;
using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.FuelCards;

public class GetFuelCardBriefPagedResultHandler :
    IRequestHandler<GetFuelCardBriefPagedResultQuery, PagedResultWithActionControls<FuelCardBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly ICardNumberHelper _cardNumberHelper;
    private readonly IAsyncAppAuthService _appAuthService;

    public GetFuelCardBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        ICardNumberHelper cardNumberHelper,
        IAsyncAppAuthService appAuthService)
    {
        _context = context;
        _mapper = mapper;
        _cardNumberHelper = cardNumberHelper;
        _appAuthService = appAuthService;
    }

    public async Task<PagedResultWithActionControls<FuelCardBriefDto>> Handle(
        GetFuelCardBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<FuelCard, FuelCardBriefDto>(_context.FuelCards.IsSoftActive());

        if (!request.CardNumber.IsNullOrEmptyObject())
        {
            var cardNumber = _cardNumberHelper.GetMasked(request.CardNumber);
            request.CardNumber = request.CardNumber.Replace("*", "_");
            query = query.Where(a => EF.Functions.Like(a.CardNumber, $"%{request.CardNumber}%"));
        }

        query = await query.SortFilter(request, _appAuthService);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _appAuthService.HasPermissionAsync(PermissionCode.FuelCardCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls: actionControls, cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_appAuthService);

        return result;
    }
}

public static class TransportBriefDtoExtension
{
    public static async Task<IEnumerable<FuelCardBriefDto>> SetActionControls(this IEnumerable<FuelCardBriefDto> query,
                                                                               IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.FuelCardView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.FuelCardEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.FuelCardDelete));
        }

        return query;
    }
}