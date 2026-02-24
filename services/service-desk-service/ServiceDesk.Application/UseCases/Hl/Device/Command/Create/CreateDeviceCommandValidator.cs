using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Devices;

public class CreateDeviceCommandValidator :
    AbstractValidator<CreateDeviceCommand>
{
	public CreateDeviceCommandValidator()
	{
        RuleFor(x => x.UniqueNumber)
            .MinimumLength(1)
            .MaximumLength(10)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDeviceCommand.UniqueNumber), 1, 10));

        //RuleFor(x => x.SerialNumber)
        //    .MaximumLength(10)
        //    .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDeviceCommand.SerialNumber), 1, 10));
    }
}
