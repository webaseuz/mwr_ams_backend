using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Districts;

public class CreateDistrictCommandHandler :
    IRequestHandler<CreateDistrictCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateDistrictCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
        CreateDistrictCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateDistrictCommand, District>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, District>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
