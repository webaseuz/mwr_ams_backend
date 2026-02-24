using MediatR;

namespace AutoPark.Application.UseCases.Departments;

public class GetDepartmentQueryHandler :
    IRequestHandler<GetDepartmentQuery, DepartmentDto>
{
    public Task<DepartmentDto> Handle(
        GetDepartmentQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new DepartmentDto());
}