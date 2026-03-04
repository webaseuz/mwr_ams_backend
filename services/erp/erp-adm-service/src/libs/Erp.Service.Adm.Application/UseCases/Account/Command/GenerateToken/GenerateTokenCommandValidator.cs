using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Accounts;

public class GenerateTokenCommandValidator :
    AbstractValidator<GenerateTokenCommand>
{
    public GenerateTokenCommandValidator()
    {
        var userIdentityTranslate = "Имя пользователя";
        var passwordTranslate = "Пароль";

        RuleFor(x => x.UserIdentity)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(userIdentityTranslate))
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(userIdentityTranslate))
            .MinimumLength(5)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(userIdentityTranslate, 5, 100))
            .MaximumLength(100)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(userIdentityTranslate, 5, 100));


        RuleFor(x => x.Password)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(passwordTranslate))
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(passwordTranslate))
            .MinimumLength(6)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(passwordTranslate, 6, 10))
            .MaximumLength(10)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(passwordTranslate, 6, 10));
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
