using MediatR;

namespace AutoPark.Application.UseCases.Roles;

public class GetRoleQueryHandler :
    IRequestHandler<GetRoleQuery, RoleDto>
{
    public Task<RoleDto> Handle(
        GetRoleQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new RoleDto());
}
