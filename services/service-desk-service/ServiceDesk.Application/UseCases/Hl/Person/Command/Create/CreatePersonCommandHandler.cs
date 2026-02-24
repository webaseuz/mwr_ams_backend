using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Persons;

public class CreatePersonCommandHandler :
    IRequestHandler<CreatePersonCommand, IHaveId<long>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreatePersonCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<long>> Handle(
        CreatePersonCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreatePersonCommand, Person>(_mapper);

        entity.SetFIO();
        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<long, Person>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
