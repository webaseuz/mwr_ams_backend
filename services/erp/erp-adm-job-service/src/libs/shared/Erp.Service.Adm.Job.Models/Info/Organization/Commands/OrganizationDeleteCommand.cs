using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}

