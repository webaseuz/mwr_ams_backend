using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportModelGetByIdQuery : IRequest<TransportModelDto>
{
    public int Id { get; set; }
}
