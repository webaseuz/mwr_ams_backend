using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class MfyDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
