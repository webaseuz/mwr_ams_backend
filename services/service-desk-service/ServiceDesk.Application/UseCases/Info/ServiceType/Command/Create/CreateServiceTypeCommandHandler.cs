using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class CreateServiceTypeCommandHandler :
    IRequestHandler<CreateServiceTypeCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateServiceTypeCommandHandler(
        IMapProvider mapper,        
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
		CreateServiceTypeCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateServiceTypeCommand, ServiceType>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, ServiceType>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
