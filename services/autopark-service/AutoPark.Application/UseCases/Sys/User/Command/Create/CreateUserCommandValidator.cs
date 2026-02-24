using AutoPark.Application.UseCases.Persons;
using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Users
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
                .MinimumLength(6)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateUserCommand.Password), 6, 10))
                .MaximumLength(10)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateUserCommand.Password), 6, 10));

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreateUserCommand.PhoneNumber)));

            RuleFor(x => x.Person)
                .NotNull()
                .SetValidator(new CreatePersonCommandValidator());
        }
    }
}
