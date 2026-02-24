using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Countries;

public class CreateCountryCommadnHandler :
    IRequestHandler<CreateCountryCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateCountryCommadnHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
        CreateCountryCommand request, 
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateCountryCommand, Country>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, Country>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
