using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Refuels;

public class GetRefuelByIdQueryValidator :
    AbstractValidator<GetRefuelByIdQuery>
{
    public GetRefuelByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GetRefuelByIdQuery.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetRefuelByIdQuery.Id), 1, int.MaxValue))
            .LessThan(long.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetRefuelByIdQuery.Id), 1, int.MaxValue));
    }
}
