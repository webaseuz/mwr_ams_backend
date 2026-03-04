namespace Erp.Service.Adm.Models;

public class ExpenseFileDto
{
    public Guid Id { get; set; }
    public long OwnerId { get; set; }
    public string FileName { get; set; }
}
