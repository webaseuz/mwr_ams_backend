using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Regions;

public class CreateRegionCommandHandler :
    IRequestHandler<CreateRegionCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public CreateRegionCommandHandler(IWriteEfCoreContext context, IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
        CreateRegionCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateRegionCommand, Region>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        return HaveId.Create(await _context.CreateAndSaveAsync<int, Region>(entity, cancellationToken));
    }
}
