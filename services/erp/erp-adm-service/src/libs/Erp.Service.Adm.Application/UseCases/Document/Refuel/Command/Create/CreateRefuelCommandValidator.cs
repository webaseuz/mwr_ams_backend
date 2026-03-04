using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases.Document.Refuel;

public class CreateRefuelCommandValidator : AbstractValidator<RefuelCreateCommand>
{
    public CreateRefuelCommandValidator()
    {
        RuleFor(x => x.DocDate).NotNull().WithMessage($"{nameof(RefuelCreateCommand.DocDate)} is required");
        RuleFor(x => x.DriverId).NotNull().WithMessage($"{nameof(RefuelCreateCommand.DriverId)} is required");
        RuleFor(x => x.TransportId).NotNull().WithMessage($"{nameof(RefuelCreateCommand.TransportId)} is required");
        RuleFor(x => x.FuelCardId).NotNull().WithMessage($"{nameof(RefuelCreateCommand.FuelCardId)} is required");
        RuleFor(x => x.FuelTypeId).NotNull().WithMessage($"{nameof(RefuelCreateCommand.FuelTypeId)} is required");
        RuleFor(x => x.Litre).NotNull().WithMessage($"{nameof(RefuelCreateCommand.Litre)} is required")
            .Must(x => x > 0).WithMessage($"{nameof(RefuelCreateCommand.Litre)} must be greater than 0");
        RuleFor(x => x.LitrePrice).NotNull().WithMessage($"{nameof(RefuelCreateCommand.LitrePrice)} is required")
            .GreaterThan(0).WithMessage($"{nameof(RefuelCreateCommand.LitrePrice)} must be greater than 0");
    }
}
