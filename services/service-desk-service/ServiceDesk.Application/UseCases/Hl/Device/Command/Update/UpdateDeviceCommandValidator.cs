using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;
using ServiceDesk.Application.UseCases.Branches;

namespace ServiceDesk.Application.UseCases.Devices;

public class UpdateDeviceCommandValidator :
    AbstractValidator<UpdateDeviceCommand>
{
    public UpdateDeviceCommandValidator()
    {
        RuleFor(x => x.Id)
           .GreaterThan(0)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceCommand.Id), 1, int.MaxValue))
           .LessThan(int.MaxValue)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceCommand.Id), 1, int.MaxValue));

        RuleFor(x => x.UniqueNumber)
            .MinimumLength(1)
            .MaximumLength(10)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceCommand.UniqueNumber), 1, 10));
    }
}
