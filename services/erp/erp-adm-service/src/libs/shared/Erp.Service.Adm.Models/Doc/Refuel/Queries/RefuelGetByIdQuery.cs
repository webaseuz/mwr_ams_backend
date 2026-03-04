using MediatR;

namespace Erp.Service.Adm.Models;

public class RefuelGetByIdQuery : IRequest<RefuelDto>
{
    public long Id { get; set; }
}
