using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationalFormCreateCommand : IRequest<int>
{
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
}
