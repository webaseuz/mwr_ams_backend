using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Departments;

public class CreateDepartmentCommandHandler :
    IRequestHandler<CreateDepartmentCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;

    public CreateDepartmentCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
        CreateDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateDepartmentCommand, Department>(_mapper);

        entity.MarkAsActive();

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        var result = await _context.CreateAndSaveAsync<int, Department>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
