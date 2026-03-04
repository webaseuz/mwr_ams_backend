using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class EduDirectionCreateCommand : IRequest<WbHaveId<int>>
{
    public string Code { get; set; }
    public string OrderCode { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public int StateId { get; set; }
    public List<EduDirectionTranslateCreateUpdateCommand> Translates { get; set; } = new List<EduDirectionTranslateCreateUpdateCommand>();

}
