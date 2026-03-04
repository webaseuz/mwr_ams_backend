using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class FileConfigGetByIdQuery : IRequest<FileConfigDto>
{
    public int Id { get; set; }
}
