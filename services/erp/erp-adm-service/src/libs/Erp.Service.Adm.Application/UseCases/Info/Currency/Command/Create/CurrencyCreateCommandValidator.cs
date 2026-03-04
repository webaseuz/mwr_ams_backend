using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CurrencyCreateCommandValidator : AbstractValidator<CurrencyCreateCommand>
{
    public CurrencyCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(CurrencyCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CurrencyCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(CurrencyCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CurrencyCreateCommand.FullName)} max length is 250");
        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage($"{nameof(CurrencyCreateCommand.Code)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CurrencyCreateCommand.Code)} max length is 250");
    }
}
