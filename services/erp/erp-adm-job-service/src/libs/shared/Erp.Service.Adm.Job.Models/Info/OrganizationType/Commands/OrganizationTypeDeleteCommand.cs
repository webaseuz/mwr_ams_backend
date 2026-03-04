using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationTypeDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
