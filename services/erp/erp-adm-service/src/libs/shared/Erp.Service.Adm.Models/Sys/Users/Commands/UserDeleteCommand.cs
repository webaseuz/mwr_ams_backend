using MediatR;

namespace Erp.Service.Adm.Models;
public class UserDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
