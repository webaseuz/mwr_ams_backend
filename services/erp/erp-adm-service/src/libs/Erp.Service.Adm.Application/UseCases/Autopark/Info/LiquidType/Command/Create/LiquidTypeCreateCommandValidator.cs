using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class LiquidTypeCreateCommandValidator : AbstractValidator<LiquidTypeCreateCommand>
{
    public LiquidTypeCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(LiquidTypeCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(LiquidTypeCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(LiquidTypeCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(LiquidTypeCreateCommand.FullName)} max length is 250");
    }
}
