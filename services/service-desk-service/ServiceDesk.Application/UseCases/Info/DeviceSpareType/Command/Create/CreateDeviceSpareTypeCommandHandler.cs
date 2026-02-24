using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class CreateDeviceSpareTypeCommandHandler :
    IRequestHandler<CreateDeviceSpareTypeCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateDeviceSpareTypeCommandHandler(
        IMapProvider mapper,        
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
		CreateDeviceSpareTypeCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateDeviceSpareTypeCommand, DeviceSpareType>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, DeviceSpareType>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
