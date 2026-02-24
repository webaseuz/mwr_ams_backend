using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Application.UseCases.Persons;

namespace ServiceDesk.Application.UseCases.Users;

public class CreateUserCommand :
    IRequest<IHaveId<int>>
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; }
    public int? OrganizationId { get; set; }
    public int PersonId { get; set; }
    public int? BranchId { get; set; }
    public int? DepartmentId { get; set; }
    public int? PositionId { get; set; }
    public int? LanguageId { get; set; }
    public List<int> Roles { get; set; } = new List<int>();

    public CreatePersonCommand Person { get; set; } = null!;
}