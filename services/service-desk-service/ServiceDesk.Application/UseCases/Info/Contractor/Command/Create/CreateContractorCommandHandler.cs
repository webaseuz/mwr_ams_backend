using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Info.Contractors;

public class CreateContractorCommandHandler :
    IRequestHandler<CreateContractorCommand, IHaveId<long>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateContractorCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<long>> Handle(
       CreateContractorCommand request,
       CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateContractorCommand, Contractor>(_mapper);

        var result = await _context.CreateAndSaveAsync<long, Contractor>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
