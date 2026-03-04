using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class StatusGetByIdQuery : IRequest<StatusDto>
{
    public int Id { get; set; }
}
