using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class EduDirectionGetByIdQuery : IRequest<EduDirectionDto>
{
    public int Id { get; set; }
}
