using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TireSizes;

public class CreateTireSizeCommandValidator :
    AbstractValidator<CreateTireSizeCommand>
{
    public CreateTireSizeCommandValidator()
    {

        RuleFor(x => x.Width)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTireSizeCommand.Width), 1, 500));

        RuleFor(x => x.Height)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTireSizeCommand.Width), 1, 500));

        RuleFor(x => x.Radius)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTireSizeCommand.Width), 1, 500));
    }
}