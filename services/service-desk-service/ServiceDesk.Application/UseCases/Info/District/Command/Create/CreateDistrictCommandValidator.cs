using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Districts;

public class CreateDistrictCommandValidator :
    AbstractValidator<CreateDistrictCommand>
{
    public CreateDistrictCommandValidator()
    {
        RuleFor(x => x.OrderCode)
            .MinimumLength(3)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDistrictCommand.OrderCode), 1, 3));

        RuleFor(x => x.Code)
            .MaximumLength(5)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDistrictCommand.Code), 1, 5));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateDistrictCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDistrictCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateDistrictCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDistrictCommand.FullName), 1, 250));
    }
}
