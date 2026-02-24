using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class CreateBatteryTypeCommandHandler :
    IRequestHandler<CreateBatteryTypeCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateBatteryTypeCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
       CreateBatteryTypeCommand request,
       CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateBatteryTypeCommand, BatteryType>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, BatteryType>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
