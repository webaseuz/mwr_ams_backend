using MediatR;

namespace Erp.Service.Adm.Models;
public class RoleDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
