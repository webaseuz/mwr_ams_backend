using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TransportModels;

public class CreateTransportModelCommandValidator :
    AbstractValidator<CreateTransportModelCommand>
{
    public CreateTransportModelCommandValidator()
    {
        RuleFor(x => x.TransportTypeId)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportModelCommand.TransportTypeId), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportModelCommand.TransportTypeId), 1, int.MaxValue));

        RuleFor(x => x.TransportBrandId)
            .NotNull()
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportModelCommand.TransportBrandId), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportModelCommand.TransportBrandId), 1, int.MaxValue));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportModelCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportModelCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportModelCommand.FullName)))
            .MaximumLength(500)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateTransportModelCommand.FullName), 1, 500));

        RuleFor(x => x.LoadCapacity)
            .NotNull()
            .GreaterThan(0)
            .When(x => x.TransportTypeId != 1)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateTransportModelCommand.LoadCapacity)));

    }
}
