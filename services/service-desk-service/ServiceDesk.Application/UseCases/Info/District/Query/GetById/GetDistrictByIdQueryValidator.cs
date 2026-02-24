using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Districts;

public class GetDistrictByIdQueryValidator :
    AbstractValidator<GetDistrictByIdQuery>
{
    public GetDistrictByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetDistrictByIdQuery.Id), 1, int.MaxValue));
    }
}
