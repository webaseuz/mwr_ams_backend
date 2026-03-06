using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CountryCreateCommandValidator : AbstractValidator<CountryCreateCommand>
{
    public CountryCreateCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage($"{nameof(CountryCreateCommand.Code)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CountryCreateCommand.Code)} max length is 250");
        RuleFor(x => x.TextCode)
            .NotEmpty()
            .WithMessage($"{nameof(CountryCreateCommand.TextCode)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CountryCreateCommand.TextCode)} max length is 250");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(CountryCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CountryCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(CountryCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CountryCreateCommand.FullName)} max length is 250");
    }
}
