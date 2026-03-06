using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CreateTrackingInfoCommandValidator : AbstractValidator<TrackingInfoCreateCommand>
{
    public CreateTrackingInfoCommandValidator()
    {
        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90)
            .WithMessage($"{nameof(TrackingInfoCreateCommand.Latitude)} must be between -90 and 90");

        RuleFor(x => x.Longitude)
            .InclusiveBetween(-180, 180)
            .WithMessage($"{nameof(TrackingInfoCreateCommand.Longitude)} must be between -180 and 180");
    }
}
