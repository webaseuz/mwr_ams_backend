using AutoPark.Application.UseCases.Nationalities;
using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class CreateLiquidTypeCommandValidator :
    AbstractValidator<CreateNationalityCommand>
{
    public CreateLiquidTypeCommandValidator()
    {
        RuleFor(x => x.ShortName)
         .NotEmpty()
         .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateLiquidTypeCommand.ShortName)))
         .MaximumLength(250)
         .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateLiquidTypeCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateLiquidTypeCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateLiquidTypeCommand.FullName), 1, 250));
    }
}
