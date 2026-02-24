using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Positions;

public class CreatePositionCommandHandler :
    IRequestHandler<CreatePositionCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public CreatePositionCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
        CreatePositionCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreatePositionCommand, Position>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, Position>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
