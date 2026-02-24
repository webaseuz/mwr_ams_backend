using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class CreateNationalityCommandHandler :
    IRequestHandler<CreateNationalityCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateNationalityCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<IHaveId<int>> Handle(
        CreateNationalityCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateNationalityCommand, Nationality>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, Nationality>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
