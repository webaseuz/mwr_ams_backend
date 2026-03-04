using Erp.Core.Models;
using MediatR;

namespace Erp.Service.Adm.Models;
public class FileConfigGetByIdQuery : IRequestGetByIdQuery<int, FileConfigDto>
{
    public int Id { get; set; }
    public bool IsDocChangeLog { get; set; }
}
