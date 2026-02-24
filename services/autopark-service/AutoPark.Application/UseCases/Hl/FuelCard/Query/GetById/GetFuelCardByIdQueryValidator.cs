using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.FuelCards;

public class GetFuelCardByIdQueryValidator :
    AbstractValidator<GetFuelCardByIdQuery>
{
    public GetFuelCardByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetFuelCardByIdQuery.Id), 1, int.MaxValue));
    }
}
