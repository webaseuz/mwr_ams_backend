
namespace ServiceDesk.Application.UseCases.Departments;

public class DepartmentBriefDto
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public string BranchName { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string OrderCode { get; set; }
    public int StateId { get; private set; }
    public bool IsDeleted { get; private set; }
    public string StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
