using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportModelDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
