using AutoPark.Application.HelperService;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AutoPark.Application.UseCases.FuelCards;

public class UpdateFuelCardCommandHandler :
    IRequestHandler<UpdateFuelCardCommand,
    IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly ICardNumberHelper _cardNumberHelper;

    public UpdateFuelCardCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        ICardNumberHelper cardNumberHelper)
    {
        _context = context;
        _mapper = mapper;
        _cardNumberHelper = cardNumberHelper;
    }

    public async Task<IHaveId<int>> Handle(
        UpdateFuelCardCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.FuelCards
                    .IsSoftActive()
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        request.UpdateEntity(entity, _mapper);

        entity.ExpireAt = DateTime.ParseExact(request.ExpireAt, "MM/yy", CultureInfo.InvariantCulture);

        if (entity.ExpireAt < DateTime.UtcNow.Date)
            throw ClientLogicalExceptionHelper.Wrap("Amal qilish mudati tugagan.", ErrorCode.CLIENT_WRONG_STATUS);

        entity.CardNumber = _cardNumberHelper.GetMasked(entity.CardNumber);

        await _context.SaveChangesAsync(cancellationToken);

        return HaveId.Create(request.Id);
    }
}
