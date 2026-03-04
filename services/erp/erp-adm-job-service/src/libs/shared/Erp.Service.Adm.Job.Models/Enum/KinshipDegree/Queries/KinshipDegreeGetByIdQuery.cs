using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class KinshipDegreeGetByIdQuery : IRequest<KinshipDegreeDto>
{
    public int Id { get; set; }
}
