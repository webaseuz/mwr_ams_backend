using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UserCreateCommandValidator : AbstractValidator<UserCreateCommand>
{
    public UserCreateCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage($"{nameof(UserCreateCommand.UserName)} is required");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage($"{nameof(UserCreateCommand.PhoneNumber)} is required");
        RuleFor(x => x.Person).NotNull().WithMessage($"{nameof(UserCreateCommand.Person)} is required");
    }
}
