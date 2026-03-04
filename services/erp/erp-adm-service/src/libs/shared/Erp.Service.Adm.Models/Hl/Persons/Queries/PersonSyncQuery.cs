using MediatR;

namespace Erp.Service.Adm.Models;
public class PersonSyncQuery : IRequest<bool>
{
    public int Id { get; set; }
    public bool IncludePhoto { get; set; }
}
