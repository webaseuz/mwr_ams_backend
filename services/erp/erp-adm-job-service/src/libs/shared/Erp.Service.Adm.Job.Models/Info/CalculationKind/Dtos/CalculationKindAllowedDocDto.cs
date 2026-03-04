namespace Erp.Service.Adm.Job.Models;

public class CalculationKindAllowedDocDto
{
    public long Id { get; set; }
    public DateTime DateOn { get; set; }
    public int TableId { get; set; }
    public string Table { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }

}
