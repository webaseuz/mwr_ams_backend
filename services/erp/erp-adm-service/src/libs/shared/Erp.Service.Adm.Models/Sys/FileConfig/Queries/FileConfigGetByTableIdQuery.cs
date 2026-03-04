using MediatR;

namespace Erp.Service.Adm.Models;
public class FileConfigGetByTableIdQuery : IRequest<IEnumerable<FileConfigDto>>
{
    public int TableId { get; set; }
}
