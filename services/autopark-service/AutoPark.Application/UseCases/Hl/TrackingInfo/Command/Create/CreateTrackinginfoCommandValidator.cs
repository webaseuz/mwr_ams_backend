using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class CreateTrackingInfoCommandValidator :
    AbstractValidator<CreateTrackingInfoCommand>
{
    public CreateTrackingInfoCommandValidator()
    {
        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90)
            .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreateTrackingInfoCommand.Latitude)));

        RuleFor(x => x.Longitude)
            .InclusiveBetween(-180, 180)
            .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreateTrackingInfoCommand.Longitude)));
    }
}
