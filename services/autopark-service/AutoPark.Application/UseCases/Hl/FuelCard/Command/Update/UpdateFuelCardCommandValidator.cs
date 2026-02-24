using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.FuelCards;

public class UpdateFuelCardCommandValidator :
    AbstractValidator<UpdateFuelCardCommand>
{
    public UpdateFuelCardCommandValidator()
    {
        RuleFor(x => x.DriverId)
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateFuelCardCommand.DriverId), 1, int.MaxValue));

        RuleFor(x => x.TransportId)
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateFuelCardCommand.TransportId), 1, int.MaxValue));

        RuleFor(x => x.PlasticCardTypeId)
            .NotNull()
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateFuelCardCommand.PlasticCardTypeId), 1, int.MaxValue));

        RuleFor(x => x.CardNumber)
            .NotEmpty()
            .Matches(@"^\d{4}\*{8}\d{4}$")
            .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreateFuelCardCommand.PlasticCardTypeId)));
    }
}
