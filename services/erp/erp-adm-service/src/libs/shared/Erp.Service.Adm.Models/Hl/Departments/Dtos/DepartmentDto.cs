namespace Erp.Service.Adm.Models;

public class DepartmentDto
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public int OrganizationId { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? OrderCode { get; set; }
    public int StateId { get; set; }
    public List<DepartmentTranslateDto> Translates { get; set; } = new();
}
