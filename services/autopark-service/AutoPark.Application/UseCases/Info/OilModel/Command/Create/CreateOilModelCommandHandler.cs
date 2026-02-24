using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.OilModels;

public class CreateOilModelCommandHandler :
    IRequestHandler<CreateOilModelCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public CreateOilModelCommandHandler(IWriteEfCoreContext context, IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(
        CreateOilModelCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateOilModelCommand, OilModel>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        return HaveId.Create(await _context.CreateAndSaveAsync<int, OilModel>(entity, cancellationToken));
    }
}
