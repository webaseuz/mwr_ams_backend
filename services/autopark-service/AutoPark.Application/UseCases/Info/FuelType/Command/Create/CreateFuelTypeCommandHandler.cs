using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.FuelTypes;

public class CreateFuelTypeCommandHandler :
    IRequestHandler<CreateFuelTypeCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateFuelTypeCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
        CreateFuelTypeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateFuelTypeCommand, FuelType>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, FuelType>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
