using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class BankUpdateCommandValidator : AbstractValidator<BankUpdateCommand>
{
    public BankUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(BankUpdateCommand.Id)} is required");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(BankUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(BankUpdateCommand.FullName)} max length is 250");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(BankUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(BankUpdateCommand.ShortName)} max length is 250");
    }
}
