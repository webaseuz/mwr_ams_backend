using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationGetByInnQuery : IRequest<OrganizationDto>
{
    public string Inn { get; set; }
}
