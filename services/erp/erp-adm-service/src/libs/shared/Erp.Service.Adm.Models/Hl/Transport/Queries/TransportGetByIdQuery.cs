using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportGetByIdQuery : IRequest<TransportDto>
{
    public int Id { get; set; }
}
