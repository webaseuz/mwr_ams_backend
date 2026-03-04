namespace Erp.Service.Adm.Job.Models;

public class CalculationKindPercentDto
{
    public long Id { get; set; }
    public DateTime DateOn { get; set; }
    public decimal PercentRate { get; set; }
    public decimal? Amount { get; set; }
    public string Details { get; set; }

}
