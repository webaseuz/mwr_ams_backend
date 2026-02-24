using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class CreateDeviceTypeCommandValidator :
    AbstractValidator<CreateDeviceTypeCommand>
{
    public CreateDeviceTypeCommandValidator()
    {
        RuleFor(x => x.OrderCode)
            .MinimumLength(3)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDeviceTypeCommand.OrderCode), 1, 3));

        //RuleFor(x => x.BaseDeviceTypeId)
        //    .NotNull()
        //    .GreaterThan(0)
        //    .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDeviceTypeCommand.BaseDeviceTypeId), 1, int.MaxValue))
        //    .LessThan(int.MaxValue)
        //    .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDeviceTypeCommand.BaseDeviceTypeId), 1, int.MaxValue));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateDeviceTypeCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDeviceTypeCommand.FullName), 1, 500));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateDeviceTypeCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDeviceTypeCommand.ShortName), 1, 250));
    }
}
