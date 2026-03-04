using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportTypeGetByIdQuery : IRequest<TransportTypeDto>
{
    public int Id { get; set; }
}
