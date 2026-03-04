using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class DistrictGetBySoatoQuery : IRequest<DistrictDto>
{
    public string Soato { get; set; }
}
