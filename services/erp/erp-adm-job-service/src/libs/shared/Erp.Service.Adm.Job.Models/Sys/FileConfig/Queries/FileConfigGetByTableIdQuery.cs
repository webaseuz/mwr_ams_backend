using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class FileConfigGetByTableIdQuery : IRequest<IEnumerable<FileConfigDto>>
{
    public int TableId { get; set; }
}
