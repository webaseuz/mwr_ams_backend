using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportTypes;

public class CreateTransportTypeCommandHandler :
    IRequestHandler<CreateTransportTypeCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public CreateTransportTypeCommandHandler(IWriteEfCoreContext context, IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
        CreateTransportTypeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateTransportTypeCommand, TransportType>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, TransportType>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
