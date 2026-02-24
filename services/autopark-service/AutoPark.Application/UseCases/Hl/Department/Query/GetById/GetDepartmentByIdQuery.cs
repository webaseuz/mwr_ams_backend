using MediatR;

namespace AutoPark.Application.UseCases.Departments;

public class GetDepartmentByIdQuery :
    IRequest<DepartmentDto>
{
    public int Id { get; set; }
}
