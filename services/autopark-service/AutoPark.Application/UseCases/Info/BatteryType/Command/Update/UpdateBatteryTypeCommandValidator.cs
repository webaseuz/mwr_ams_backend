using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class UpdateBatteryTypeCommandValidator :
    AbstractValidator<UpdateBatteryTypeCommand>
{
    public UpdateBatteryTypeCommandValidator()
    {
        RuleFor(x => x.Id)
          .GreaterThan(0)
          .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateBatteryTypeCommand.Id), 1, int.MaxValue))
          .LessThan(int.MaxValue)
          .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateBatteryTypeCommand.Id), 1, int.MaxValue));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateBatteryTypeCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateBatteryTypeCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateBatteryTypeCommand.FullName)))
            .MaximumLength(500)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateBatteryTypeCommand.FullName), 1, 500));
    }
}
