using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TireSizes;

public class UpdateTireSizeCommandValidator :
    AbstractValidator<UpdateTireSizeCommand>
{
    public UpdateTireSizeCommandValidator()
    {
        RuleFor(x => x.Width)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTireSizeCommand.Width), 1, 500));

        RuleFor(x => x.Height)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTireSizeCommand.Width), 1, 500));

        RuleFor(x => x.Radius)
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateTireSizeCommand.Width), 1, 500));
    }
}
