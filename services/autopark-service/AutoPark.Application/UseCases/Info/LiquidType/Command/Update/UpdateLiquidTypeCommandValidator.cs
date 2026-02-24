using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class UpdateLiquidTypeCommandValidator :
        AbstractValidator<UpdateLiquidTypeCommand>
{
    public UpdateLiquidTypeCommandValidator()
    {
        RuleFor(x => x.Id)
        .GreaterThan(0)
        .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateLiquidTypeCommand.Id), 1, int.MaxValue))
        .LessThan(int.MaxValue)
        .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateLiquidTypeCommand.Id), 1, int.MaxValue));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateLiquidTypeCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateLiquidTypeCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateLiquidTypeCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateLiquidTypeCommand.FullName), 1, 250));
    }
}

