using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationFormDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}

