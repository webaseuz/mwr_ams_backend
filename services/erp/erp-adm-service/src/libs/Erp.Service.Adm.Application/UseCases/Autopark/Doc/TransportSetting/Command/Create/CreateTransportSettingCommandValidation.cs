using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CreateTransportSettingCommandValidation : AbstractValidator<TransportSettingCreateCommand>
{
    public CreateTransportSettingCommandValidation()
    {
        RuleFor(x => x.TransportId)
            .NotNull().WithMessage($"{nameof(TransportSettingCreateCommand.TransportId)} is required");

        RuleFor(x => x.DriverId)
            .NotNull().WithMessage($"{nameof(TransportSettingCreateCommand.DriverId)} is required");

        RuleFor(x => x.LicenseNumber)
            .NotEmpty().WithMessage($"{nameof(TransportSettingCreateCommand.LicenseNumber)} is required")
            .MaximumLength(50).WithMessage($"{nameof(TransportSettingCreateCommand.LicenseNumber)} must not exceed 50 characters");

        RuleFor(x => x.LicenseEndAt)
            .NotNull().WithMessage($"{nameof(TransportSettingCreateCommand.LicenseEndAt)} is required");

        RuleFor(x => x.PoaNumber)
            .NotEmpty().WithMessage($"{nameof(TransportSettingCreateCommand.PoaNumber)} is required")
            .MaximumLength(50).WithMessage($"{nameof(TransportSettingCreateCommand.PoaNumber)} must not exceed 50 characters");

        RuleFor(x => x.PoaEndAt)
            .NotNull().WithMessage($"{nameof(TransportSettingCreateCommand.PoaEndAt)} is required");

        RuleFor(x => x.ManagerFullName)
            .MaximumLength(250).WithMessage($"{nameof(TransportSettingCreateCommand.ManagerFullName)} must not exceed 250 characters");

        RuleFor(x => x.SeatCount)
            .NotNull().WithMessage($"{nameof(TransportSettingCreateCommand.SeatCount)} is required");

        RuleFor(x => x.OdometrIndicator)
            .NotNull().WithMessage($"{nameof(TransportSettingCreateCommand.OdometrIndicator)} is required");

        RuleFor(x => x.ResponsiblePersonId)
            .NotNull().WithMessage($"{nameof(TransportSettingCreateCommand.ResponsiblePersonId)} is required");
    }
}
