using MediatR;

namespace Erp.Service.Adm.Models;

public class OrganizationGetByIdQuery : IRequest<OrganizationDto>
{
    public int Id { get; set; }
}
