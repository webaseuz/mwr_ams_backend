using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Report.SpareTurnover;

[Keyless]
public class SpareTurnoverReportJson
{
    [Column("result")]
    public string Result { get; set; } = default!;
}
