using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportColorGetByIdQuery : IRequest<TransportColorDto>
{
    public int Id { get; set; }
}
