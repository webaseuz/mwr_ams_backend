using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class CreateDeviceModelCommandHandler :
    IRequestHandler<CreateDeviceModelCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateDeviceModelCommandHandler(
        IMapProvider mapper,        
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
		CreateDeviceModelCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateDeviceModelCommand, DeviceModel>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, DeviceModel>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
