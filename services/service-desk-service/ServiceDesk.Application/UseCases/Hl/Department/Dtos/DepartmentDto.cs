namespace ServiceDesk.Application.UseCases.Departments;

public class DepartmentDto
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string Code { get; set; }
    public string OrderCode { get; set; }
    public int StateId { get; private set; }
    public bool IsDeleted { get; private set; }
}
