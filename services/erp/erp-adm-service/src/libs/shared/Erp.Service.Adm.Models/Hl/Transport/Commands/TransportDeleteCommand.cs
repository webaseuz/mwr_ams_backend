using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
