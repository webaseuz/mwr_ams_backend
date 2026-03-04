using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class CalculationKindCreateCommand : IRequest<WbHaveId<int>>
{
    public string Code { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string NormativeDoc { get; set; }
    public DateTime StartOn { get; set; }
    public DateTime? EndOn { get; set; }
    public int? ItemOfExpenseId { get; set; }
    public int CalculationTypeId { get; set; }
    public int? CalculationMethodId { get; set; }
    public int? MinimumValueTypeId { get; set; }
    public int? CalculateByTimeTypeId { get; set; }
    public int StateId { get; set; }
    public bool DependOnRate { get; set; } = false;
    public bool ByEnrolment { get; set; } = false;
    public bool IsMandatory { get; set; } = false;

    public List<CalculationKindPercentDto> Percents { get; set; } = new();
    public List<CalculationKindAllowedDocDto> Docs { get; set; } = new();
    public List<CalculationKindUsedTableDto> UsedTables { get; set; } = new();
    public List<CalculationKindTranslateCommand> Translates { get; set; } = new();
}
