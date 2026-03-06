using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases.Document.Refuel;

public class UpdateRefuelCommandValidator : AbstractValidator<RefuelUpdateCommand>
{
    public UpdateRefuelCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage($"{nameof(RefuelUpdateCommand.Id)} is required");
        RuleFor(x => x.DocDate).NotNull().WithMessage($"{nameof(RefuelUpdateCommand.DocDate)} is required");
        RuleFor(x => x.DriverId).NotNull().WithMessage($"{nameof(RefuelUpdateCommand.DriverId)} is required");
        RuleFor(x => x.TransportId).NotNull().WithMessage($"{nameof(RefuelUpdateCommand.TransportId)} is required");
        RuleFor(x => x.FuelCardId).NotNull().WithMessage($"{nameof(RefuelUpdateCommand.FuelCardId)} is required");
        RuleFor(x => x.FuelTypeId).NotNull().WithMessage($"{nameof(RefuelUpdateCommand.FuelTypeId)} is required");
        RuleFor(x => x.Litre).NotNull().WithMessage($"{nameof(RefuelUpdateCommand.Litre)} is required")
            .Must(x => x > 0).WithMessage($"{nameof(RefuelUpdateCommand.Litre)} must be greater than 0");
        RuleFor(x => x.LitrePrice).NotNull().WithMessage($"{nameof(RefuelUpdateCommand.LitrePrice)} is required")
            .GreaterThan(0).WithMessage($"{nameof(RefuelUpdateCommand.LitrePrice)} must be greater than 0");
    }
}
