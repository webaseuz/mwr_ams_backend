using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class FileConfigDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
