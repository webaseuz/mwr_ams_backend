using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationTypeGetByIdQuery : IRequest<OrganizationTypeDto>
{
    public int Id { get; set; }

}
