using MediatR;

namespace Erp.Service.Adm.Models;

public class TireSizeGetByIdQuery : IRequest<TireSizeDto>
{
    public int Id { get; set; }
}
