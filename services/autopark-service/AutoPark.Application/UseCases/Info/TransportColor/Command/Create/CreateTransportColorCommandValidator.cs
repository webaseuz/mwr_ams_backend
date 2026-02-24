using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TransportColors;

public class CreateTransportColorCommandValidator :
    AbstractValidator<CreateTransportColorCommand>
{
    public CreateTransportColorCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportColorCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportColorCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportColorCommand.FullName)))
            .MaximumLength(500)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportColorCommand.FullName), 1, 500));
    }
}
