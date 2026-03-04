namespace Erp.Service.Adm.Job.Models;

public class ItemOfExpenseDto
{
    public int Id { get; set; }
    public int NumberOfGroup { get; set; }
    public string Code => $"{Code1}-{Code2}-{Code3}";
    public string Code1 { get; set; } 
    public string Code2 { get; set; } 
    public string Code3 { get; set; } 
    public string ShortName { get; set; } 
    public string FullName { get; set; }
    public bool IsGroup { get; set; }
    public int StateId { get; set; }
    public int? ParentId { get; set; }
    public bool AgeingAllowed { get; set; }
    public string State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public List<ItemOfExpenseTranslateDto> Translates { get; set; } = new List<ItemOfExpenseTranslateDto>();
}
