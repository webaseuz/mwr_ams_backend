using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class RoleDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
