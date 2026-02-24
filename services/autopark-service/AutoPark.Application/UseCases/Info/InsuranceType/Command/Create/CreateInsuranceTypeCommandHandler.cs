using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.InsuranceTypes;

public class CreateInsuranceTypeCommandHandler :
    IRequestHandler<CreateInsuranceTypeCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateInsuranceTypeCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
        CreateInsuranceTypeCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateInsuranceTypeCommand, InsuranceType>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, InsuranceType>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
