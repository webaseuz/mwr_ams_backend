using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class PermissionSelectListQuery : IRequest<IEnumerable<PermissionGroupSelectListDto>>
{
    public int? AppId { get; set; }
}
