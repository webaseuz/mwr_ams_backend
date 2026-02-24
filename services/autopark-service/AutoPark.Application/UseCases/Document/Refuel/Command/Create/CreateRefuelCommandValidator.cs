using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Refuels;

public class CreateRefuelCommandValidator :
    AbstractValidator<CreateRefuelCommand>
{
    public CreateRefuelCommandValidator()
    {
        RuleFor(x => x.DocDate)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateRefuelCommand.DocDate)));

        RuleFor(x => x.DriverId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateRefuelCommand.DriverId)));

        RuleFor(x => x.TransportId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateRefuelCommand.TransportId)));

        RuleFor(x => x.FuelCardId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateRefuelCommand.FuelCardId)));

        RuleFor(x => x.FuelTypeId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateRefuelCommand.FuelTypeId)));

        RuleFor(x => x.Litre)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateRefuelCommand.Litre)))
            .Must(x => x > 0)
            .Failure(ClientValidationExceptionHelper.InvalidMinLengthProperty(nameof(CreateRefuelCommand.Litre), 1));

        RuleFor(x => x.LitrePrice)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateRefuelCommand.LitrePrice)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidMinLengthProperty(nameof(CreateRefuelCommand.LitrePrice), 0));

    }
}
