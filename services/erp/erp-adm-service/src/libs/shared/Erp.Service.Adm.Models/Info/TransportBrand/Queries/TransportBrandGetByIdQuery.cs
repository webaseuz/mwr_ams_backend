using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportBrandGetByIdQuery : IRequest<TransportBrandDto>
{
    public int Id { get; set; }
}
