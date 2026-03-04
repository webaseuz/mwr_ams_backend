using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class LiquidTypeUpdateCommandValidator : AbstractValidator<LiquidTypeUpdateCommand>
{
    public LiquidTypeUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(LiquidTypeUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(LiquidTypeUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(LiquidTypeUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(LiquidTypeUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(LiquidTypeUpdateCommand.FullName)} max length is 250");
    }
}
