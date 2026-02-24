using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.OilModels;

public class CreateOilModelCommandValidator :
    AbstractValidator<CreateOilModelCommand>
{
    public CreateOilModelCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateOilModelCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateOilModelCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateOilModelCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateOilModelCommand.FullName), 1, 500));

        RuleFor(x => x.OilTypeId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateOilModelCommand.OilTypeId)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateOilModelCommand.OilTypeId), 0, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateOilModelCommand.OilTypeId), 0, int.MaxValue));

    }
}
