using MediatR;

namespace ServiceDesk.Application.UseCases.Departments;

public class GetDepartmentQuery :
    IRequest<DepartmentDto>
{ }
