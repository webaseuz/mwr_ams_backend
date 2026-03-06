using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class FuelTypeUpdateCommandValidator : AbstractValidator<FuelTypeUpdateCommand>
{
    public FuelTypeUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(FuelTypeUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(FuelTypeUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(FuelTypeUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(FuelTypeUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(FuelTypeUpdateCommand.FullName)} max length is 250");
    }
}
