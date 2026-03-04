using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class InstitutionTypeCreateCommand : IRequest<WbHaveId<int>>
{
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int OrganizationTypeId { get; set; }
    public string FinalYear { get; set; }
    public int StateId { get; set; }
    public List<InstitutionTypeTranslateCreateUpdateCommand> Translates { get; set; } = new List<InstitutionTypeTranslateCreateUpdateCommand>();
}
