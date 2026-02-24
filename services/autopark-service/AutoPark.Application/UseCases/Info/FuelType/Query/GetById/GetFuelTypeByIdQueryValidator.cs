using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.FuelTypes;

public class GetFuelTypeByIdQueryValidator :
    AbstractValidator<GetFuelTypeByIdQuery>
{
    public GetFuelTypeByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetFuelTypeByIdQuery.Id), 1, int.MaxValue));
    }
}
