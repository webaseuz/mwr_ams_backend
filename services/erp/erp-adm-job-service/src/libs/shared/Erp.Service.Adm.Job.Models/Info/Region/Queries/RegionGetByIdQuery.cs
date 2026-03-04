using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class RegionGetByIdQuery : IRequest<RegionDto>
{
    public int Id { get; set; }
}
