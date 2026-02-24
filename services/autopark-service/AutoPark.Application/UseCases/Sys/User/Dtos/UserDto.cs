using AutoPark.Application.UseCases.Persons;

namespace AutoPark.Application.UseCases.Users;

public class UserDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }
    public int OrganizationId { get; set; }
    public string OrganizationName { get; set; }
    public int BranchId { get; set; }
    public string BranchName { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int? LanguageId { get; set; }
    public string LanguageName { get; set; }
    public int PositionId { get; set; }
    public string PositionName { get; set; }
    public List<int> Roles { get; set; } = new List<int>();

    public PersonDto Person { get; set; }
}
