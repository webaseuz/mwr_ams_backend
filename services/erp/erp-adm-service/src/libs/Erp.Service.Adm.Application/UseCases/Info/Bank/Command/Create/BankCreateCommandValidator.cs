using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class BankCreateCommandValidator : AbstractValidator<BankCreateCommand>
{
    public BankCreateCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(BankCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(BankCreateCommand.FullName)} max length is 250");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(BankCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(BankCreateCommand.ShortName)} max length is 250");
    }
}
