using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class SpecialtyUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public string OrderCode { get; set; }
    public int DirectionId { get; set; }
    public int StateId { get; set; }

    public List<SpecialtyTranslateCreateUpdateCommand> Translates { get; set; } = new List<SpecialtyTranslateCreateUpdateCommand>();
}
