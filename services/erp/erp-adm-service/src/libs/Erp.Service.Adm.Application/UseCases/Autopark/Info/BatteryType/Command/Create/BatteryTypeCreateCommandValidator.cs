using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class BatteryTypeCreateCommandValidator : AbstractValidator<BatteryTypeCreateCommand>
{
    public BatteryTypeCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(BatteryTypeCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(BatteryTypeCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(BatteryTypeCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(BatteryTypeCreateCommand.FullName)} max length is 250");
    }
}
