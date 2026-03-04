using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Roles;

public class CreateRoleCommandHandler :
    IRequestHandler<CreateRoleCommand, IHaveId<int>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;
    public CreateRoleCommandHandler(
        IMapProvider mapper,
        IWriteEfCoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IHaveId<int>> Handle(
        CreateRoleCommand request,
        CancellationToken cancellationToken)
    {
        var entity = request.CreateEntity<CreateRoleCommand, Role>(_mapper);

        request.Translates.AddByUniqueFKTo(entity.Translates, _mapper);

        entity.RolePermissions.AddFromForeignKeys(request.RolePermissions);

        entity.MarkAsActive();

        var result = await _context.CreateAndSaveAsync<int, Role>(entity, cancellationToken);

        return HaveId.Create(result);
    }
}
