using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportUseTypeDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
