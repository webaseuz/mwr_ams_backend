using AutoPark.Application.UseCases.Persons;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Users;

public class UpdateUserCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; }
    public int StateId { get; set; }
    public int OrganizationId { get; set; }
    public int BranchId { get; set; }
    public int? DepartmentId { get; set; }
    public int? LanguageId { get; set; }
    public int? PositionId { get; set; }
    public List<int> Roles { get; set; } = new List<int>();

    public UpdatePersonCommand Person { get; set; } = null!;
}