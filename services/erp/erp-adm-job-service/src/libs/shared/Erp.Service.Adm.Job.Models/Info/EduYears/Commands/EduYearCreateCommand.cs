using System.Text.Json.Serialization;
using Erp.Core.Extensions;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class EduYearCreateCommand : IRequest<WbHaveId<int>>
{
    public string Code { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int? CurrentYear { get; set; }
    public int? Adm.JobissionYear { get; set; }
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime StartDate { get; set; }
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime EndDate { get; set; }
    public int? PreviousYearId { get; set; }
    public int? Allowed { get; set; }
    public int StateId { get; set; }
    public List<EduYearTranslateCreateUpdateCommand> Translates { get; set; } = new List<EduYearTranslateCreateUpdateCommand>();
}
