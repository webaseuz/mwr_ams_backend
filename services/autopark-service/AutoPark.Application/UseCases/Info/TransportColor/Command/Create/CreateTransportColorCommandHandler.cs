using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportColors;

public class CreateTransportColorCommandHandler :
    IRequestHandler<CreateTransportColorCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public CreateTransportColorCommandHandler(IWriteEfCoreContext context, IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
        CreateTransportColorCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateTransportColorCommand, TransportColor>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, TransportColor>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
