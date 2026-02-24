using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class CreateCitizenshipCommandHandler :
    IRequestHandler<CreateCitizenshipCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateCitizenshipCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<IHaveId<int>> Handle(
        CreateCitizenshipCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateCitizenshipCommand, Citizenship>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, Citizenship>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
