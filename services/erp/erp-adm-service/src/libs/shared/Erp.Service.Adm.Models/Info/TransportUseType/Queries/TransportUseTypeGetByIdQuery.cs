using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportUseTypeGetByIdQuery : IRequest<TransportUseTypeDto>
{
    public int Id { get; set; }
}
