using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportBrands;

public class CreateTransportBrandCommandHandler :
    IRequestHandler<CreateTransportBrandCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public CreateTransportBrandCommandHandler(IWriteEfCoreContext context, IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
        CreateTransportBrandCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateTransportBrandCommand, TransportBrand>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, TransportBrand>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
