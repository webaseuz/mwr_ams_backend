using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class EduYearUpdateCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int? CurrentYear { get; set; }
    public int? Adm.JobissionYear { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? PreviousYearId { get; set; }
    public int? Allowed { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }

    public List<EduYearTranslateCreateUpdateCommand> Translates { get; set; } = new List<EduYearTranslateCreateUpdateCommand>();

}
