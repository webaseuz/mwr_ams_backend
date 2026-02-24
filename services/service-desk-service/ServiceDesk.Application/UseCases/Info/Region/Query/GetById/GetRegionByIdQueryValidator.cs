using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Regions;

public class GetRegionByIdQueryValidator :
	AbstractValidator<GetRegionByIdQuery>
{
    public GetRegionByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GetRegionByIdQuery.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetRegionByIdQuery.Id), 1, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetRegionByIdQuery.Id), 1, int.MaxValue));
    }
}
