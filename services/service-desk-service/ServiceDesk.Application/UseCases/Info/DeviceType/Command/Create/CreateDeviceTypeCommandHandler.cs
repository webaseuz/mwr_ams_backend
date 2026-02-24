using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class CreateDeviceTypeCommandHandler :
    IRequestHandler<CreateDeviceTypeCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateDeviceTypeCommandHandler(
        IMapProvider mapper,        
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
		CreateDeviceTypeCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateDeviceTypeCommand, DeviceType>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, DeviceType>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
