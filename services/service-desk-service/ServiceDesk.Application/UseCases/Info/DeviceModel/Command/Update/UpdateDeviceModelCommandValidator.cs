using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class UpdateDeviceModelCommandValidator :
    AbstractValidator<UpdateDeviceModelCommand>
{
    public UpdateDeviceModelCommandValidator()
    {
		RuleFor(x => x.Id)
			.NotNull()
			.GreaterThan(0)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceModelCommand.Id), 1, int.MaxValue))
			.LessThan(int.MaxValue)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceModelCommand.Id), 1, int.MaxValue));

		RuleFor(x => x.OrderCode)
            .MinimumLength(3)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceModelCommand.OrderCode), 1, 3));

        RuleFor(x => x.DeviceTypeId)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceModelCommand.DeviceTypeId), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceModelCommand.DeviceTypeId), 1, int.MaxValue));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateDeviceModelCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceModelCommand.FullName), 1, 500));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateDeviceModelCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceModelCommand.ShortName), 1, 250));
    }
}
