using MediatR;

namespace AutoPark.Application.UseCases.Departments;

public class GetDepartmentQuery :
    IRequest<DepartmentDto>
{ }
