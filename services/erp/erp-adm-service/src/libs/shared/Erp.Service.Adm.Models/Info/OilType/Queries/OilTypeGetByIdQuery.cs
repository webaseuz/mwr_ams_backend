using MediatR;

namespace Erp.Service.Adm.Models;

public class OilTypeGetByIdQuery : IRequest<OilTypeDto>
{
    public int Id { get; set; }
}
