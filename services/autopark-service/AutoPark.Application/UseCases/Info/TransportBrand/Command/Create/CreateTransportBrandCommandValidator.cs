using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TransportBrands;

public class CreateTransportBrandCommandValidator :
    AbstractValidator<CreateTransportBrandCommand>
{
    public CreateTransportBrandCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportBrandCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportBrandCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportBrandCommand.FullName)))
            .MaximumLength(500)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportBrandCommand.FullName), 1, 500));
    }
}
