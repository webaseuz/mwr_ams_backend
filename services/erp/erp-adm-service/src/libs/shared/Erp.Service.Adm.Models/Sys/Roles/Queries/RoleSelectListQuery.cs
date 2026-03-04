using MediatR;

namespace Erp.Service.Adm.Models;
public class RoleSelectListQuery : IRequest<IEnumerable<RoleSelectListDto>>
{
    public int? AppId { get; set; }
}
