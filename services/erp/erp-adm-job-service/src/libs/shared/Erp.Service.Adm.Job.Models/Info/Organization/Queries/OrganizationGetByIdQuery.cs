using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationGetByIdQuery : IRequest<OrganizationDto>
{
    public int Id { get; set; }
}
