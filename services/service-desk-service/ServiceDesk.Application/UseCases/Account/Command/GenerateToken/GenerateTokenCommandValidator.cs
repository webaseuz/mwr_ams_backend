using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Accounts;

public class GenerateTokenCommandValidator :
    AbstractValidator<GenerateTokenCommand>
{
    public GenerateTokenCommandValidator()
    {
        RuleFor(x => x.UserIdentity)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GenerateTokenCommand.UserIdentity)))
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GenerateTokenCommand.UserIdentity)))
            .MinimumLength(5)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GenerateTokenCommand.UserIdentity), 5, 100))
            .MaximumLength(100)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GenerateTokenCommand.UserIdentity), 5, 100));


        RuleFor(x => x.Password)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GenerateTokenCommand.Password)))
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GenerateTokenCommand.Password)))
            .MinimumLength(6)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GenerateTokenCommand.Password), 6, 10))
            .MaximumLength(10)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GenerateTokenCommand.Password), 6, 10));
            /*.Matches(@"[A-Z]")
            .WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]")
            .WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"\d")
            .WithMessage("Password must contain at least one number.")
            .Matches(@"[\W_]")
            .WithMessage("Password must contain at least one special character.")*/
    }
}
