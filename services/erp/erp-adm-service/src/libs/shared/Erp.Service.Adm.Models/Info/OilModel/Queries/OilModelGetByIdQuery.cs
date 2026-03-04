using MediatR;

namespace Erp.Service.Adm.Models;

public class OilModelGetByIdQuery : IRequest<OilModelDto>
{
    public int Id { get; set; }
}
