using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Departments;

public class DeleteDepartmentCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
