using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class EduDirectionUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string OrderCode { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public int StateId { get; set; }

    public List<EduDirectionTranslateCreateUpdateCommand> Translates { get; set; } = new List<EduDirectionTranslateCreateUpdateCommand>();

}
