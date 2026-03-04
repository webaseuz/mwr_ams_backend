using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationTypeUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
    public List<OrganizationTypeTranslateCreateUpdateCommand> Translates { get; set; } = new List<OrganizationTypeTranslateCreateUpdateCommand>();

}
