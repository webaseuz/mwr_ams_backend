using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportTypeDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
