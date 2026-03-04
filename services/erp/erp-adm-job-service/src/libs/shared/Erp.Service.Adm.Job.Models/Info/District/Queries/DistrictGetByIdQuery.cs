using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class DistrictGetByIdQuery : IRequest<DistrictDto>
{
    public int Id { get; set; }
}
