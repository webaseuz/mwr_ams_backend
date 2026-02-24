using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TireSizes;

public class CreateTireSizeCommandHandler :
    IRequestHandler<CreateTireSizeCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    public CreateTireSizeCommandHandler(IWriteEfCoreContext context, IMapProvider mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IHaveId<int>> Handle(CreateTireSizeCommand request,
                                     CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateTireSizeCommand, TireSize>(_mapper);

        var result = await _context.CreateAndSaveAsync<int, TireSize>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
