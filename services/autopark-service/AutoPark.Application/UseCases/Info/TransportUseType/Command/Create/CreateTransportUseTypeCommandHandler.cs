using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class CreateTransportUseTypeCommandHandler :
    IRequestHandler<CreateTransportUseTypeCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public CreateTransportUseTypeCommandHandler(IWriteEfCoreContext context, IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
        CreateTransportUseTypeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateTransportUseTypeCommand, TransportUseType>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, TransportUseType>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
