using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class UpdateDevicePartCommandValidator :
    AbstractValidator<UpdateDevicePartCommand>
{
    public UpdateDevicePartCommandValidator()
    {
		RuleFor(x => x.Id)
			.NotNull()
			.GreaterThan(0)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDevicePartCommand.Id), 1, int.MaxValue))
			.LessThan(int.MaxValue)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDevicePartCommand.Id), 1, int.MaxValue));

		RuleFor(x => x.OrderCode)
            .MinimumLength(3)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDevicePartCommand.OrderCode), 1, 3));

        RuleFor(x => x.DeviceTypeId)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDevicePartCommand.DeviceTypeId), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDevicePartCommand.DeviceTypeId), 1, int.MaxValue));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateDevicePartCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDevicePartCommand.FullName), 1, 500));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateDevicePartCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDevicePartCommand.ShortName), 1, 250));
    }
}
