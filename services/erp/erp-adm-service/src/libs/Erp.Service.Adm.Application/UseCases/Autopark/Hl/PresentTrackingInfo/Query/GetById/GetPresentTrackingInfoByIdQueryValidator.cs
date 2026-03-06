using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class GetPresentTrackingInfoByIdQueryValidator : AbstractValidator<PresentTrackingInfoGetByIdQuery>
{
    public GetPresentTrackingInfoByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(PresentTrackingInfoGetByIdQuery.Id)} is required");
    }
}
