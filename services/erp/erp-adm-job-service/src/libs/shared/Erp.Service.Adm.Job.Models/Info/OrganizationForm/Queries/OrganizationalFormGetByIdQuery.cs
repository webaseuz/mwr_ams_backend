using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationalFormGetByIdQuery : IRequest<OrganizationFormDto>
{
    public int Id { get; set; }
}
