using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.OilTypes;

public class CreateOilTypeCommandHandler :
    IRequestHandler<CreateOilTypeCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public CreateOilTypeCommandHandler(IWriteEfCoreContext context, IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
        CreateOilTypeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateOilTypeCommand, OilType>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        return HaveId.Create(await _context.CreateAndSaveAsync<int, OilType>(entity, cancellationToken));
    }
}
