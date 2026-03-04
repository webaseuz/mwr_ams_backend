using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class CreateOrganizationTypeCommand : IRequest<WbHaveId<int>>
{
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public List<OrganizationTypeTranslateCreateUpdateCommand> Translates { get; set; } = new List<OrganizationTypeTranslateCreateUpdateCommand>();
}
