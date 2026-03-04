using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class MfyGetByIdQuery : IRequest<MfyDto>
{
    public int? Id { get; set; }
}
