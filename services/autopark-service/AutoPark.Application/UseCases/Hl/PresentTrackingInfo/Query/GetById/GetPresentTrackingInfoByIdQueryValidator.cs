using AutoPark.Application.UseCases.Positions;
using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class GetPresentTrackingInfoByIdQueryValidator :
    AbstractValidator<GetPresentTrackingInfoByIdQuery>
{
    public GetPresentTrackingInfoByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GetPositionByIdQuery.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetPositionByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetPositionByIdQuery.Id), 1, int.MaxValue));
    }
}
