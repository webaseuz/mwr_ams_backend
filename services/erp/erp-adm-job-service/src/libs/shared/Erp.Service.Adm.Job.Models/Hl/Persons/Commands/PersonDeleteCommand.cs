using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class PersonDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}

