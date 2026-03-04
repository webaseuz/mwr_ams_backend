namespace Erp.Service.Adm.Job.Models;

public class CalculationKindUsedTableDto
{
    public long Id { get; set; }
    public DateTime StartOn { get; set; }
    public DateTime? EndOn { get; set; }
    public bool CalcFromInSum { get; set; }
    public int FormedCalculationKindId { get; set; }
    public string FormedCalculationKind { get; set; }
    public int? MinimumValueTypeId { get; set; }
    public string MinimumValueType { get; set; }
    public decimal? QuantityOfMinimumValue { get; set; }

}
