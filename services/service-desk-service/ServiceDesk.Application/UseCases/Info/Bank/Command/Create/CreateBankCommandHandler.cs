using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Banks;

public class CreateBankCommandHandler :
    IRequestHandler<CreateBankCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateBankCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
        CreateBankCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateBankCommand, Bank>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, Bank>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
