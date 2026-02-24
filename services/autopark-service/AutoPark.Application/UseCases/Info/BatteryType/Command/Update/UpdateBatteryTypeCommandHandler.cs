using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class UpdateBatteryTypeCommandHandler :
    IRequestHandler<UpdateBatteryTypeCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public UpdateBatteryTypeCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
       UpdateBatteryTypeCommand request,
       CancellationToken cancellationToken)
    {
        var entity = await _context.BatteryTypes
            .Include(b => b.Translates)
            .IsSoftActive()
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        request.UpdateEntity(entity, _mapper);

        request.Translates.ApplyChangesByUniqueFKTo(entity.Translates, _mapper);

        await _context.SaveChangesAsync(cancellationToken);

        return HaveId.Create(request.Id);
    }


}
