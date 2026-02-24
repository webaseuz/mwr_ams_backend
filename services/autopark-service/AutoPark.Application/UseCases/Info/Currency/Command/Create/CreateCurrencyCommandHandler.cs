using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Currencies;

public class CreateCurrencyCommandHandler :
    IRequestHandler<CreateCurrencyCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateCurrencyCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
        CreateCurrencyCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateCurrencyCommand, Currency>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, Currency>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
