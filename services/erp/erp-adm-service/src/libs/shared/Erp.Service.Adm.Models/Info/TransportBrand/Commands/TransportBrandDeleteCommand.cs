using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportBrandDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
