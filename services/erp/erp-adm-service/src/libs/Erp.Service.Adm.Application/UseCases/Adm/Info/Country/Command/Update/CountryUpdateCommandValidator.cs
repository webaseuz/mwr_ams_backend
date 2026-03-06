using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CountryUpdateCommandValidator : AbstractValidator<CountryUpdateCommand>
{
    public CountryUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(CountryUpdateCommand.Id)} is required");
        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage($"{nameof(CountryUpdateCommand.Code)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CountryUpdateCommand.Code)} max length is 250");
        RuleFor(x => x.TextCode)
            .NotEmpty()
            .WithMessage($"{nameof(CountryUpdateCommand.TextCode)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CountryUpdateCommand.TextCode)} max length is 250");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(CountryUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CountryUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(CountryUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(CountryUpdateCommand.FullName)} max length is 250");
    }
}
