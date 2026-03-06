using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UserUpdateCommandValidator : AbstractValidator<UserUpdateCommand>
{
    public UserUpdateCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage($"{nameof(UserUpdateCommand.Id)} is required");
    }
}
