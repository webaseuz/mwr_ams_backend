using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class DocumentStatusDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
