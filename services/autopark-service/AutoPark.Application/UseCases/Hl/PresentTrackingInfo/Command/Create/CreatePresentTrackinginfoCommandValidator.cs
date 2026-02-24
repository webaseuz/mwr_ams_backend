using FluentValidation;

namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class CreatePresentTrackingInfoCommandValidator :
    AbstractValidator<CreatePresentTrackingInfoCommand>
{
    public CreatePresentTrackingInfoCommandValidator()
    {/*
        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90)
            .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreatePresentTrackingInfoCommand.Latitude)));

        RuleFor(x => x.Longitude)
            .InclusiveBetween(-180, 180)
            .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreatePresentTrackingInfoCommand.Longitude)));*/
    }
}
