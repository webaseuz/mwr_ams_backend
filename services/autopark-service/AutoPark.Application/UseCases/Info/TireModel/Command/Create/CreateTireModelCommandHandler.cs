using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TireModels;

public class CreateTireModelCommandHandler :
    IRequestHandler<CreateTireModelCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public CreateTireModelCommandHandler(IWriteEfCoreContext context, IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
        CreateTireModelCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateTireModelCommand, TireModel>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        return HaveId.Create(await _context.CreateAndSaveAsync<int, TireModel>(entity, cancellationToken));
    }
}
