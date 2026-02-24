using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

class UpdateLiquidTypeCommandHandler :
       IRequestHandler<UpdateLiquidTypeCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public UpdateLiquidTypeCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IHaveId<int>> Handle(
        UpdateLiquidTypeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.LiquidTypes
            .Include(b => b.Translates)
            .Where(a => a.StateId == StateIdConst.ACTIVE)
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (entity == null)
            throw ClientLogicalExceptionHelper.NotFound(request.Id);

        request.UpdateEntity(entity, _mapper);

        request.Translates.ApplyChangesByUniqueFKTo(entity.Translates, _mapper);

        await _context.SaveChangesAsync(cancellationToken);

        return HaveId.Create(request.Id);
    }
}
