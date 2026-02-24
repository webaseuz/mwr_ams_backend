using MediatR;

namespace AutoPark.Application.UseCases.Permissons;

public class GetPermissionSelectListQuery :
    IRequest<IEnumerable<PermissionGroupSelectListDto>>
{
}
