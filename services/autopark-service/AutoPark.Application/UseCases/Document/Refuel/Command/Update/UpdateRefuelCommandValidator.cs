using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Refuels;

public class UpdateRefuelCommandValidator :
    AbstractValidator<UpdateRefuelCommand>
{
    public UpdateRefuelCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateRefuelCommand.Id)));

        RuleFor(x => x.DocDate)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateRefuelCommand.DocDate)));

        RuleFor(x => x.DriverId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateRefuelCommand.DriverId)));

        RuleFor(x => x.TransportId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateRefuelCommand.TransportId)));

        RuleFor(x => x.FuelCardId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateRefuelCommand.FuelCardId)));

        RuleFor(x => x.FuelTypeId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateRefuelCommand.FuelTypeId)));

        RuleFor(x => x.Litre)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateRefuelCommand.Litre)))
            .Must(x => x > 0)
            .Failure(ClientValidationExceptionHelper.InvalidMinLengthProperty(nameof(UpdateRefuelCommand.Litre), 1));

        RuleFor(x => x.LitrePrice)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateRefuelCommand.LitrePrice)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidMinLengthProperty(nameof(UpdateRefuelCommand.LitrePrice), 0));
    }
}
