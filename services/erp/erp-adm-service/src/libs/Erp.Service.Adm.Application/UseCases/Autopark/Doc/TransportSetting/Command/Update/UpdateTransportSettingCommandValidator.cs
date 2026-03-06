using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UpdateTransportSettingCommandValidator : AbstractValidator<TransportSettingUpdateCommand>
{
    public UpdateTransportSettingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage($"{nameof(TransportSettingUpdateCommand.Id)} is required");

        RuleFor(x => x.TransportId)
            .NotNull().WithMessage($"{nameof(TransportSettingUpdateCommand.TransportId)} is required");

        RuleFor(x => x.DriverId)
            .NotNull().WithMessage($"{nameof(TransportSettingUpdateCommand.DriverId)} is required");

        RuleFor(x => x.LicenseNumber)
            .NotEmpty().WithMessage($"{nameof(TransportSettingUpdateCommand.LicenseNumber)} is required")
            .MaximumLength(50).WithMessage($"{nameof(TransportSettingUpdateCommand.LicenseNumber)} must not exceed 50 characters");

        RuleFor(x => x.LicenseEndAt)
            .NotNull().WithMessage($"{nameof(TransportSettingUpdateCommand.LicenseEndAt)} is required");

        RuleFor(x => x.PoaNumber)
            .NotEmpty().WithMessage($"{nameof(TransportSettingUpdateCommand.PoaNumber)} is required")
            .MaximumLength(50).WithMessage($"{nameof(TransportSettingUpdateCommand.PoaNumber)} must not exceed 50 characters");

        RuleFor(x => x.PoaEndAt)
            .NotNull().WithMessage($"{nameof(TransportSettingUpdateCommand.PoaEndAt)} is required");

        RuleFor(x => x.ManagerFullName)
            .MaximumLength(250).WithMessage($"{nameof(TransportSettingUpdateCommand.ManagerFullName)} must not exceed 250 characters");

        RuleFor(x => x.SeatCount)
            .NotNull().WithMessage($"{nameof(TransportSettingUpdateCommand.SeatCount)} is required");

        RuleFor(x => x.OdometrIndicator)
            .NotNull().WithMessage($"{nameof(TransportSettingUpdateCommand.OdometrIndicator)} is required");

        RuleFor(x => x.ResponsiblePersonId)
            .NotNull().WithMessage($"{nameof(TransportSettingUpdateCommand.ResponsiblePersonId)} is required");
    }
}
