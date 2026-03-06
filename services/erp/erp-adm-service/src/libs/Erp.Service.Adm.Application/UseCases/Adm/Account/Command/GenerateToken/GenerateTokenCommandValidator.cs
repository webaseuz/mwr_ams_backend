using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GenerateTokenCommandValidator : AbstractValidator<GenerateTokenCommand>
{
    public GenerateTokenCommandValidator()
    {
        RuleFor(x => x.UserIdentity)
            .NotNull().WithMessage("Имя пользователя не может быть пустым")
            .NotEmpty().WithMessage("Имя пользователя не может быть пустым")
            .MinimumLength(5).WithMessage("Имя пользователя должно содержать от 5 до 100 символов")
            .MaximumLength(100).WithMessage("Имя пользователя должно содержать от 5 до 100 символов");

        RuleFor(x => x.Password)
            .NotNull().WithMessage("Пароль не может быть пустым")
            .NotEmpty().WithMessage("Пароль не может быть пустым")
            .MinimumLength(6).WithMessage("Пароль должен содержать от 6 до 10 символов")
            .MaximumLength(10).WithMessage("Пароль должен содержать от 6 до 10 символов");
    }
}
