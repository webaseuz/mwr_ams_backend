using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TransportSettings;

public class UpdateTransportSettingCommandValidator :
    AbstractValidator<UpdateTransportSettingCommand>
{
    public UpdateTransportSettingCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotNull()
           .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportSettingCommand.Id)));

        RuleFor(x => x.TransportId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportSettingCommand.TransportId)));

        RuleFor(x => x.DriverId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportSettingCommand.DriverId)));

        RuleFor(x => x.LicenseNumber)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportSettingCommand.LicenseNumber)))
            .MaximumLength(50)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTransportSettingCommand.LicenseNumber), 1, 50));

        RuleFor(x => x.LicenseEndAt)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportSettingCommand.LicenseEndAt)));

        RuleFor(x => x.PoaNumber)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportSettingCommand.PoaNumber)))
            .MaximumLength(50)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTransportSettingCommand.PoaNumber), 1, 50));

        RuleFor(x => x.PoaEndAt)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportSettingCommand.PoaEndAt)));

        RuleFor(x => x.ManagerFullName)
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTransportSettingCommand.ManagerFullName), 1, 250));

        //RuleFor(x => x.LoadCapacity)
        //    .NotNull()
        //    .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportSettingCommand.LoadCapacity)));

        RuleFor(x => x.SeatCount)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportSettingCommand.SeatCount)));

        RuleFor(x => x.OdometrIndicator)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportSettingCommand.OdometrIndicator)));

        RuleFor(x => x.ResponsiblePersonId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateTransportSettingCommand.ResponsiblePersonId)));
    }
}
