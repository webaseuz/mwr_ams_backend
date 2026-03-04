using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class BatteryTypeUpdateCommandValidator : AbstractValidator<BatteryTypeUpdateCommand>
{
    public BatteryTypeUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(BatteryTypeUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(BatteryTypeUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(BatteryTypeUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(BatteryTypeUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(BatteryTypeUpdateCommand.FullName)} max length is 250");
    }
}
