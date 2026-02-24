using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Users;

public class DeleteUserCommand :
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}