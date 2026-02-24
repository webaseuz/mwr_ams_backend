using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class CreateLiquidTypeCommandHandler :
    IRequestHandler<CreateLiquidTypeCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateLiquidTypeCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<IHaveId<int>> Handle(
        CreateLiquidTypeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateLiquidTypeCommand, LiquidType>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, LiquidType>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
