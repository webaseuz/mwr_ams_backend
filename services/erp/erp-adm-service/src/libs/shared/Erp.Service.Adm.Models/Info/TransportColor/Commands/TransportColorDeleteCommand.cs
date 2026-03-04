using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportColorDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
