using MediatR;

namespace Erp.Service.Adm.Models;

public class PermissionSelectListQuery : IRequest<IEnumerable<PermissionGroupSelectListDto>>
{
}