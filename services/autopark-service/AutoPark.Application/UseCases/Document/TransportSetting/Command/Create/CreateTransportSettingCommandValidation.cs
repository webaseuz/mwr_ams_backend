using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TransportSettings;

public class CreateTransportSettingCommandValidation :
    AbstractValidator<CreateTransportSettingCommand>
{
    public CreateTransportSettingCommandValidation()
    {
        RuleFor(x => x.TransportId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportSettingCommand.TransportId)));

        RuleFor(x => x.DriverId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportSettingCommand.DriverId)));

        RuleFor(x => x.LicenseNumber)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportSettingCommand.LicenseNumber)))
            .MaximumLength(50)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportSettingCommand.LicenseNumber), 1, 50));

        RuleFor(x => x.LicenseEndAt)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportSettingCommand.LicenseEndAt)));

        RuleFor(x => x.PoaNumber)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportSettingCommand.PoaNumber)))
            .MaximumLength(50)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportSettingCommand.PoaNumber), 1, 50));

        RuleFor(x => x.PoaEndAt)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportSettingCommand.PoaEndAt)));

        RuleFor(x => x.ManagerFullName)
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportSettingCommand.ManagerFullName), 1, 250));

        //RuleFor(x => x.LoadCapacity)
        //    .NotNull()
        //    .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportSettingCommand.LoadCapacity)));

        RuleFor(x => x.SeatCount)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportSettingCommand.SeatCount)));

        RuleFor(x => x.OdometrIndicator)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportSettingCommand.OdometrIndicator)));

        RuleFor(x => x.ResponsiblePersonId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportSettingCommand.ResponsiblePersonId)));
    }
}
