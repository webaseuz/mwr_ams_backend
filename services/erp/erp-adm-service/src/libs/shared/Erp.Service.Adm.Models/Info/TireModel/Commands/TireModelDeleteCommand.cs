using MediatR;

namespace Erp.Service.Adm.Models;

public class TireModelDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
