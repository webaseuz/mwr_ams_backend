using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Users;

public class UpdateUserCommandValidator :
    AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.UserName)
                .NotEmpty()
                .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateUserCommand.UserName)))
                .MaximumLength(250)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateUserCommand.UserName), 1, 250));

        RuleFor(x => x.Password)
            .MinimumLength(8)
            .When(x => !string.IsNullOrEmpty(x.Password))
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateUserCommand.Password), 8, 20))
            .MaximumLength(20)
            .When(x => !string.IsNullOrEmpty(x.Password))
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateUserCommand.Password), 8, 20));


        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
            .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreateUserCommand.PhoneNumber)));
    }
}