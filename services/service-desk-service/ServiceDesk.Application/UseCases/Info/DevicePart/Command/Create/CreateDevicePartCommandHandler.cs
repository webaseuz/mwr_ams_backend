using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class CreateDevicePartCommandHandler :
    IRequestHandler<CreateDevicePartCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateDevicePartCommandHandler(
        IMapProvider mapper,        
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
		CreateDevicePartCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateDevicePartCommand, DevicePart>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, DevicePart>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
