using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class UpdateDeviceSpareTypeCommandValidator :
    AbstractValidator<UpdateDeviceSpareTypeCommand>
{
    public UpdateDeviceSpareTypeCommandValidator()
    {
		RuleFor(x => x.Id)
			.NotNull()
			.GreaterThan(0)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceSpareTypeCommand.DeviceTypeId), 1, int.MaxValue))
			.LessThan(int.MaxValue)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceSpareTypeCommand.DeviceTypeId), 1, int.MaxValue));

		RuleFor(x => x.OrderCode)
			.MinimumLength(3)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceSpareTypeCommand.OrderCode), 1, 3));

		RuleFor(x => x.DeviceTypeId)
			.NotNull()
			.GreaterThan(0)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceSpareTypeCommand.DeviceTypeId), 1, int.MaxValue))
			.LessThan(int.MaxValue)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceSpareTypeCommand.DeviceTypeId), 1, int.MaxValue));

		RuleFor(x => x.DevicePartId)
			.NotNull()
			.GreaterThan(0)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceSpareTypeCommand.DevicePartId), 1, int.MaxValue))
			.LessThan(int.MaxValue)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceSpareTypeCommand.DevicePartId), 1, int.MaxValue));

		RuleFor(x => x.DeviceModelId)
			.GreaterThan(0)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceSpareTypeCommand.DeviceModelId), 1, int.MaxValue))
			.LessThan(int.MaxValue)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceSpareTypeCommand.DeviceModelId), 1, int.MaxValue));

		RuleFor(x => x.FullName)
			.NotEmpty()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateDeviceSpareTypeCommand.FullName)))
			.MaximumLength(250)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceSpareTypeCommand.FullName), 1, 500));

		RuleFor(x => x.ShortName)
			.NotEmpty()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateDeviceSpareTypeCommand.ShortName)))
			.MaximumLength(250)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceSpareTypeCommand.ShortName), 1, 250));
	}
}
