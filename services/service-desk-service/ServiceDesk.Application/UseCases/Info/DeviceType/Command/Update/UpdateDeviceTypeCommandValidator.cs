using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class UpdateDeviceTypeCommandValidator :
    AbstractValidator<UpdateDeviceTypeCommand>
{
    public UpdateDeviceTypeCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceTypeCommand.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceTypeCommand.Id), 1, int.MaxValue));

        RuleFor(x => x.OrderCode)
            .MinimumLength(3)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceTypeCommand.OrderCode), 1, 3));

        //RuleFor(x => x.BaseDeviceTypeId)
        //    .NotNull()
        //    .GreaterThan(0)
        //    .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceTypeCommand.BaseDeviceTypeId), 1, int.MaxValue))
        //    .LessThan(int.MaxValue)
        //    .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceTypeCommand.BaseDeviceTypeId), 1, int.MaxValue));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateDeviceTypeCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceTypeCommand.FullName), 1, 500));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateDeviceTypeCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDeviceTypeCommand.ShortName), 1, 250));
    }
}
