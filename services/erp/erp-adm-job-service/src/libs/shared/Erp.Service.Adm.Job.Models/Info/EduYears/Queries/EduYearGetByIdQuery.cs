using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class EduYearGetByIdQuery : IRequest<EduYearDto>
{
    public int Id { get; set; }

}
