using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class UserDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
