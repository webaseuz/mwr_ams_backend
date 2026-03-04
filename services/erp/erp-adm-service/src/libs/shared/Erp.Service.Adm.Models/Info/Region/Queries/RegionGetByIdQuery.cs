using MediatR;

namespace Erp.Service.Adm.Models;

public class RegionGetByIdQuery : IRequest<RegionDto>
{
    public int Id { get; set; }
}
