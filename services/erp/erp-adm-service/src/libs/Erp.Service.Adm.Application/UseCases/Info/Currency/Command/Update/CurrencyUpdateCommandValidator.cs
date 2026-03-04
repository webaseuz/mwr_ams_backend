using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CurrencyUpdateCommandValidator : AbstractValidator<CurrencyUpdateCommand>
{
    public CurrencyUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(CurrencyUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(CurrencyUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CurrencyUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(CurrencyUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CurrencyUpdateCommand.FullName)} max length is 250");
        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage($"{nameof(CurrencyUpdateCommand.Code)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CurrencyUpdateCommand.Code)} max length is 250");
    }
}
