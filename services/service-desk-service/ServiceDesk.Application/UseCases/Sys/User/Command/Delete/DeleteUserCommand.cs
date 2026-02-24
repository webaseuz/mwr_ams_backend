using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Users;

public class DeleteUserCommand : 
    IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}