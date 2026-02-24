using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Branches;

public class CreateBranchCommandHandler :
    IRequestHandler<CreateBranchCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateBranchCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
        CreateBranchCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateBranchCommand, Branch>(_mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, Branch>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}