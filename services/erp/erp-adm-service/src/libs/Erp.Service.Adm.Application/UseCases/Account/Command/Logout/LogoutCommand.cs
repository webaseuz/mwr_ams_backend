using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Accounts;

public class LogoutCommand :
    IRequest<SuccessResult<bool>>
{ }
