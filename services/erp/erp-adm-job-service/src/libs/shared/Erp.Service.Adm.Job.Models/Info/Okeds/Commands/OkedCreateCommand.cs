using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OkedCreateCommand : IRequest<WbHaveId<int>>
{
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int IsGroup { get; set; }
    public int? ParentId { get; set; }
    public string OrderCode { get; set; }

    public List<OkedTranslateCreateUpdateCommand> Translates { get; set; } = new List<OkedTranslateCreateUpdateCommand>();

}
