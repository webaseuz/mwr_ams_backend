using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Users
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateUserCommand.UserName)))
                .MaximumLength(250)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateUserCommand.UserName), 1, 250));

            RuleFor(x => x.Password)
                .NotEmpty()
                .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateUserCommand.Password)))
                .MinimumLength(8)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateUserCommand.Password), 8, 20))
                .MaximumLength(20)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateUserCommand.Password), 8, 20));

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreateUserCommand.PhoneNumber)));
        }
    }
}
