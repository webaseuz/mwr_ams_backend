using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Accounts;

public class LogoutCommand :
    IRequest<SuccessResult<bool>>
{}
