namespace Erp.Service.Adm.Job.Models;

public class CalculationKindBriefDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string NormativeDoc { get; set; }
    public DateTime StartOn { get; set; }
    public DateTime? EndOn { get; set; }
    public int? ItemOfExpenseId { get; set; }
    public string ItemOfExpense { get; set; }
    public int CalculationTypeId { get; set; }
    public string CalculationType { get; set; }
    public int? CalculationMethodId { get; set; }
    public string CalculationMethod { get; set; }
    public int? MinimumValueTypeId { get; set; }
    public string MinimumValueType { get; set; }
    public int? CalculateByTimeTypeId { get; set; }
    public int? UzasboId { get; set; }
    public string CalculateByTimeType { get; set; }
    public bool DependOnRate { get; set; } = false;
    public bool ByEnrolment { get; set; } = false;
    public bool IsMandatory { get; set; } = false;

    public int StateId { get; set; }
    public string State { get; set; }

}
