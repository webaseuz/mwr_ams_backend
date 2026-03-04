using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class AppGetByIdQuery : IRequest<AppDto>
{
    public int Id { get; set; }
}
