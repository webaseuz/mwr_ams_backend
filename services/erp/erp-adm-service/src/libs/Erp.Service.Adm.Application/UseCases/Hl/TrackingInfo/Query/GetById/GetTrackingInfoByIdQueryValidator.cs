using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GetTrackingInfoByIdQueryValidator : AbstractValidator<TrackingInfoGetByIdQuery>
{
    public GetTrackingInfoByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(TrackingInfoGetByIdQuery.Id)} is required");
    }
}
