using MediatR;

namespace Erp.Service.Adm.Models;
public class FileConfigDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
