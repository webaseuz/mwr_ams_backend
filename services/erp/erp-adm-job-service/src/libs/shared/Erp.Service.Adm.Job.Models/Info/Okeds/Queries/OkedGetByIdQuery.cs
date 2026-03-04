using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class OkedGetByIdQuery : IRequest<OkedDto>
{
    public int Id { get; set; }
}


