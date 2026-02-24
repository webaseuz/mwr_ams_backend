using AutoPark.Application.HelperService;
using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using System.Globalization;

namespace AutoPark.Application.UseCases.FuelCards;

public class CreateFuelCardCommandHandler :
    IRequestHandler<CreateFuelCardCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    private readonly ICardNumberHelper _cardNumberHelper;

    public CreateFuelCardCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService,
        ICardNumberHelper cardNumberHelper)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
        _cardNumberHelper = cardNumberHelper;
    }

    public async Task<IHaveId<int>> Handle(
        CreateFuelCardCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateFuelCardCommand, FuelCard>(_mapper);

        var userInfo = await _authService.GetUserAsync();
        if (!await _authService.HasPermissionAsync(PermissionCode.CreateFuelCardForAllBranch))
            request.BranchId = userInfo.BranchId.Value;

        entity.ExpireAt = DateTime.ParseExact(request.ExpireAt, "MM/yy", CultureInfo.InvariantCulture);

        if (entity.ExpireAt < DateTime.UtcNow.Date)
            throw ClientLogicalExceptionHelper.Wrap("Amal qilish mudati tugagan.", ErrorCode.CLIENT_WRONG_STATUS);

        entity.MarkAsActive();
        entity.CardNumber = _cardNumberHelper.GetMasked(entity.CardNumber);

        var res = await _context.CreateAndSaveAsync<int, FuelCard>(entity, cancellationToken);

        return HaveId.Create(res);
    }
}
