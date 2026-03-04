using MediatR;

namespace Erp.Service.Adm.Models;

public class TireModelGetByIdQuery : IRequest<TireModelDto>
{
    public int Id { get; set; }
}
